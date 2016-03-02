/* ***********************************************
 * author :  LinJiarui
 * email  :  lin@bimer.cn
 * file   :  ViewModel
 * history:  created by LinJiarui at 2016/2/29 20:17:25
 *           modified by
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf.SharpDX;
using SharpDX;
using MeshGeometry3D = HelixToolkit.Wpf.SharpDX.MeshGeometry3D;
using PerspectiveCamera = HelixToolkit.Wpf.SharpDX.PerspectiveCamera;

namespace IfcViewer.DX
{

    public class MainViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public MainViewModel ViewModel { get { return this; } }
        private Element3DCollection model;

        public Element3DCollection Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }
        public MeshGeometry3D Sphere { get; private set; }
        public Transform3D Light1Transform { get; private set; }
        public Transform3D Light2Transform { get; private set; }
        public Transform3D Light3Transform { get; private set; }
        public Transform3D Light4Transform { get; private set; }
        public Transform3D Light1DirectionTransform { get; private set; }
        public Transform3D Light4DirectionTransform { get; private set; }

        public PhongMaterial LightModelMaterial { get; set; }

        public Vector3 Light1Direction { get; set; }
        public Vector3 Light4Direction { get; set; }
        public Vector3D LightDirection4 { get; set; }
        public Color4 Light1Color { get; set; }
        public Color4 Light2Color { get; set; }
        public Color4 Light3Color { get; set; }
        public Color4 Light4Color { get; set; }
        public Color4 AmbientLightColor { get; set; }
        public Vector3 Light2Attenuation { get; set; }
        public Vector3 Light3Attenuation { get; set; }
        public Vector3 Light4Attenuation { get; set; }
        public bool RenderLight1 { get; set; }
        public bool RenderLight2 { get; set; }
        public bool RenderLight3 { get; set; }
        public bool RenderLight4 { get; set; }

        public bool RenderFaces
        {
            get
            {
                if (viewController != null) {
                    return viewController.Faces;
                }
                return false;
            }
            set
            {
                if (viewController != null) {
                    viewController.Faces = value;
                }
            }
        }

        public bool RenderWireframes
        {
            get
            {
                if (viewController != null) {
                    return viewController.WireFrames;
                }
                return false;
            }
            set
            {
                if (viewController != null) {
                    viewController.WireFrames = value;
                }
            }
        }
        public bool ShowSpaces
        {
            get
            {
                if (viewController != null) {
                    return viewController.ShowSpaces;
                }
                return false;
            }
            set
            {
                if (viewController != null) {
                    viewController.ShowSpaces = value;
                }
            }
        }
        public bool ShowElements
        {
            get
            {
                if (viewController != null) {
                    return viewController.ShowElements;
                }
                return false;
            }
            set
            {
                if (viewController != null) {
                    viewController.ShowElements = value;
                }
            }
        }

        ViewController viewController;
        public MainViewModel(Viewport3DX viewport, TreeView treeview)
        {
            // ----------------------------------------------
            // titles
            this.Title = "Ifc Viewer";
            this.SubTitle = "By LinJiarui";

            // ----------------------------------------------
            // camera setup
            this.Camera = new PerspectiveCamera { Position = new Point3D(8, 9, 7), LookDirection = new Vector3D(-5, -12, -5), UpDirection = new Vector3D(0, 0, 1) };

            // ----------------------------------------------
            // setup scene
            this.AmbientLightColor = new Color4(0.2f, 0.2f, 0.2f, 1.0f);

            this.RenderLight1 = true;
            this.RenderLight2 = false;
            this.RenderLight3 = false;
            this.RenderLight4 = true;

            this.Light1Color = (Color4)Color.White;
            this.Light2Color = (Color4)Color.Red;
            this.Light3Color = (Color4)Color.LightYellow;
            this.Light4Color = (Color4)Color.LightBlue;

            this.Light2Attenuation = new Vector3(1.0f, 0.5f, 0.10f);
            this.Light3Attenuation = new Vector3(1.0f, 0.1f, 0.05f);
            this.Light4Attenuation = new Vector3(1.0f, 0.2f, 0.0f);

            this.Light1Direction = new Vector3(0, -10, -10);
            this.Light1Transform = new TranslateTransform3D(-Light1Direction.ToVector3D());
            //            this.Light1DirectionTransform = CreateAnimatedTransform2(-Light1Direction.ToVector3D(), new Vector3D(0, 1, -1), 24);

            //            this.Light2Transform = CreateAnimatedTransform1(new Vector3D(-4, 0, 0), new Vector3D(0, 0, 1), 3);
            //            this.Light3Transform = CreateAnimatedTransform1(new Vector3D(0, 0, 4), new Vector3D(0, 1, 0), 5);

            this.Light4Direction = new Vector3(0, -5, 0);
            this.Light4Transform = new TranslateTransform3D(-Light4Direction.ToVector3D());
            //            this.Light4DirectionTransform = CreateAnimatedTransform2(-Light4Direction.ToVector3D(), new Vector3D(1, 0, 0), 12);

            // ----------------------------------------------
            // light model3d
            var sphere = new MeshBuilder();
            sphere.AddSphere(new Vector3(0, 0, 0), 0.2);
            Sphere = sphere.ToMeshGeometry3D();
            this.LightModelMaterial = new PhongMaterial {
                AmbientColor = Color.Gray,
                DiffuseColor = Color.Gray,
                EmissiveColor = Color.Yellow,
                SpecularColor = Color.Black,
            };


            viewController = new ViewController();
            Model = new Element3DCollection();
            viewController.InitGraphics(viewport, Model, treeview);
        }

        private Transform3D CreateAnimatedTransform1(Vector3D translate, Vector3D axis, double speed = 4)
        {
            var lightTrafo = new Transform3DGroup();
            lightTrafo.Children.Add(new TranslateTransform3D(translate));

            var rotateAnimation = new Rotation3DAnimation {
                RepeatBehavior = RepeatBehavior.Forever,
                By = new AxisAngleRotation3D(axis, 90),
                Duration = TimeSpan.FromSeconds(speed / 4),
                IsCumulative = true,
            };

            var rotateTransform = new RotateTransform3D();
            rotateTransform.BeginAnimation(RotateTransform3D.RotationProperty, rotateAnimation);
            lightTrafo.Children.Add(rotateTransform);

            return lightTrafo;
        }

        private Transform3D CreateAnimatedTransform2(Vector3D translate, Vector3D axis, double speed = 4)
        {
            var lightTrafo = new Transform3DGroup();
            lightTrafo.Children.Add(new TranslateTransform3D(translate));

            var rotateAnimation = new Rotation3DAnimation {
                RepeatBehavior = RepeatBehavior.Forever,
                //By = new AxisAngleRotation3D(axis, 180),
                From = new AxisAngleRotation3D(axis, 135),
                To = new AxisAngleRotation3D(axis, 225),
                AutoReverse = true,
                Duration = TimeSpan.FromSeconds(speed / 4),
                //IsCumulative = true,                  
            };

            var rotateTransform = new RotateTransform3D();
            rotateTransform.BeginAnimation(RotateTransform3D.RotationProperty, rotateAnimation);
            lightTrafo.Children.Add(rotateTransform);
            return lightTrafo;
        }

        public void OpenFile(string file)
        {
            viewController.OpenIFCFile(file);
        }

        public void ZoomExtent(Viewport3DX viewport, double animationTime = 200)
        {
            var c = viewController.Center;
            var center = new Point3D(c.X, c.Y, c.Z);
            var radius = (viewController.Max - viewController.Min).Length() * 0.5;
            var camera = this.Camera;

            var pcam = camera as HelixToolkit.Wpf.SharpDX.PerspectiveCamera;
            if (pcam != null) {
                pcam.FarPlaneDistance = radius * 100;
                pcam.NearPlaneDistance = radius * 0.02;

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
