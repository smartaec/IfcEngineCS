using HelixToolkit.Wpf.SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace IfcSharpDXSampleProject
{
    public class ViewModel : ViewModelBase
    {
        ViewController viewController;



        public ViewModel(Viewport3DX viewport, TreeView _treeview)
        {
            Viewport3D = viewport;
            viewController = new ViewController();
            Model = new Element3DCollection();
            viewController.InitGraphics(Viewport3D, Model, _treeview);
        }

        public void ParseFile(string fileName)
        {
            Model.Clear();
            viewController.OpenIFCFile(fileName);
            Rect3D bounds = FindBounds();
            ZoomExtents(Viewport3D, bounds);
            Viewport3D.ReAttach();
            Viewport3D.ReAttach();
        }

        private Viewport3DX _Viewport3D;
        public Viewport3DX Viewport3D
        {
            get
            {
                return _Viewport3D;
            }
            set
            {
                _Viewport3D = value;
                RaisePropertyChangedEvent("Viewport3D");
            }
        }

        private Element3DCollection model;
        public Element3DCollection Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                RaisePropertyChangedEvent("Model");
            }
        }

        private bool _ShowFireFrame;
        public bool ShowFireFrame
        {
            get
            {
                if (!_ShowFireFrame) {
                    Model.Where(x => x is LineGeometryModel3D).ToList().ForEach(x => x.IsRendering = false);
                } else {
                    Model.Where(x => x is LineGeometryModel3D).ToList().ForEach(x => x.IsRendering = true);
                }
                return _ShowFireFrame;
            }
            set
            {
                _ShowFireFrame = value;
                RaisePropertyChangedEvent("ShowFireFrame");
            }
        }

        public Rect3D FindBounds()
        {
            var bounds = new global::SharpDX.BoundingBox();
            foreach (var element in Model) {
                var model = element as IBoundable;
                if (model != null) {
                    if (model.Visibility != Visibility.Collapsed) {
                        bounds = global::SharpDX.BoundingBox.Merge(bounds, model.Bounds);
                    }
                }
            }
            return new Rect3D(bounds.Minimum.ToPoint3D(), (bounds.Maximum - bounds.Minimum).ToSize3D());
        }

        public void ZoomExtents(Viewport3DX viewport, Rect3D bounds)
        {
            var diagonal = new Vector3D(bounds.SizeX, bounds.SizeY, bounds.SizeZ);
            var center = bounds.Location + (diagonal * 0.5);
            double radius = diagonal.Length * 0.5;
            HelixToolkit.Wpf.SharpDX.PerspectiveCamera Camera = new HelixToolkit.Wpf.SharpDX.PerspectiveCamera() {

                Position = new Point3D(center.X + 30, center.Y + 30, center.Z + 50),
                LookDirection = new Vector3D(-30, -30, -50),
                UpDirection = new Vector3D(0, 0, 1),
                FarPlaneDistance = radius * 10,
                FieldOfView = 45,
                NearPlaneDistance = 0.1 * radius,

            };
            viewport.Camera.Reset();
            viewport.Camera = Camera;
        }

        /// <summary>
        /// Zooms to the extents of the specified bounding sphere.
        /// </summary>
        /// <param name="viewport">The viewport.</param>
        /// <param name="center">The center of the sphere.</param>
        /// <param name="radius">The radius of the sphere.</param>
        /// <param name="animationTime">The animation time.</param>
        public static void ZoomExtent(Viewport3DX viewport, Point3D center, double radius, double animationTime = 0)
        {
            var camera = viewport.Camera;
            var pcam = camera as HelixToolkit.Wpf.SharpDX.PerspectiveCamera;
            if (pcam != null) {
                double disth = radius / Math.Tan(0.5 * pcam.FieldOfView * Math.PI / 180);
                double vfov = pcam.FieldOfView / viewport.ActualWidth * viewport.ActualHeight;
                double distv = radius / Math.Tan(0.5 * vfov * Math.PI / 180);

                double dist = Math.Max(disth, distv);
                var dir = pcam.LookDirection;
                dir.Normalize();
                pcam.LookAt(center, dir * dist, animationTime);
            }

            var ocam = camera as HelixToolkit.Wpf.SharpDX.OrthographicCamera;
            if (ocam != null) {
                ocam.LookAt(center, ocam.LookDirection, animationTime);
                double newWidth = radius * 2;

                if (viewport.ActualWidth > viewport.ActualHeight) {
                    newWidth = radius * 2 * viewport.ActualWidth / viewport.ActualHeight;
                }

                ocam.AnimateWidth(newWidth, animationTime);
            }
        }



    }
}
