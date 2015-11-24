KoobooWebMatrixExtension
========================

### How to Execute

Project already added to WebMatrix Extensions and just open Webmatrix and in Extensions Windows search for Kooboo Extensions, or visit
WebMatrix Extensions page:

   http://extensions.webmatrix.com/packages/KoobooExtensions/1.0
   
### A Sample to Create WebMatrix Extensions

You'll probably want to start by having a look at KoobooWebMatrixExtension.cs which contains the framework for the new extension. Most of the interesting extension points are found on the IWebMatrixHost interface which is available to the extension via the WebMatrixHost property.   

### How to Compile and Debug

The extension is already configured (via pre- and post-build steps) to publish
itself to the right location when compiled. To configure it for easy debugging,
please perform the following steps:

1. Open the "Project" menu
2. Select "KoobooWebMatrixExtension Properties" at the bottom
3. Switch to the "Debug" tab
4. Select "Start external program:"
5. Click the "..." browse button beside it
6. Browse to WebMatrix.exe at:
      %ProgramFiles%\Microsoft WebMatrix\WebMatrix.exe
7. Press F5 and WebMatrix will automatically start and load the extension

Have fun!
