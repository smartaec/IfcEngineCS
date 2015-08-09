# IfcEngineCS
This is a CSharp wrapper for the famous IfcEngine.dll (http://rdf.bg). Though a basic PInvoke wrapper has already provided, the users have to deal with different platforms (x86 or x64), and there is a lack of uniform API for different platforms. This is why I create this project.
In this repo, there is a CSharp wrapper for IfcEngine, and also a simple Ifc Viewer based on CSharp and Helix-toolkit. When creating this project, C# examples and the API doc provided by RDF Ltd. were the main references, many thanks to them.

## Features
1. Support AnyCpu, no need to use different wrapper for different platforms, the project will handle this;
2. Better API, use enums for engine settings, masks, and value types;
3. CSharp style for methods naming;
4. A CSharp version of Ifc Viewer based on Helix-toolkit and this wrapper, demostrates how to use this wrapper.

## License
this project follows MIT license (http://opensource.org/licenses/MIT); other libs or files follow there own license which listed as follows:

1. both x86 and x64 version of IfcEngine.dll ( as well as *-Setting.xml) are the products of RDF Ltd., refer to there website (http://rdf.bg) for license information;
2. Helix-toolkit: refer to (https://github.com/helix-toolkit/helix-toolkit) for license information.

## Furture works
1. Remove some unused functions;
2. More features for Ifc Viewer;
3. ...
