Option Explicit
Sub ToReveal()
    'where to save the reveal
    Dim rootFolder As String
    rootFolder = "E:\cloud\Dropbox\Development\stromdao-docs\decks\"
    
    
    Dim sld As slide, shp As Shape
    Dim textSlide As String
    Dim p As Presentation
    Set p = ActivePresentation
    Dim name As String
    name = p.name
    If (InStr(1, p.name, ".") > 1) Then
        name = Mid(name, 1, InStr(1, p.name, ".") - 1)
    End If
    Dim NameFolder As String
    NameFolder = rootFolder + name + "_reveal"
    
    ActivePresentation.SaveCopyAs NameFolder, ppSaveAsJPG
    Dim Sections As String, i As Integer, max As Integer
    max = p.Slides.Count
    
    
    For i = 1 To max
        Sections = Sections + vbCrLf
        Sections = Sections + "<section>"
        Sections = Sections + "<img src='Slide" & i & ".jpg'>"
        Sections = Sections + "</section>"
        
    Next i
    Dim str As String
    str = OriginalReveal()
    str = Replace(str, "#PPTName#", p.name)
    str = Replace(str, "#section#", Sections)
    
    Dim fileName As String, textRow As String, fileNo As Integer
    fileName = NameFolder + "\index.html"
    fileNo = FreeFile 'Get first free file number
     
    Open fileName For Output As #fileNo
    Print #fileNo, str
    Close #fileNo
    
End Sub
Function OriginalReveal() As String

OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "<!doctype html>" + vbCrLf
OriginalReveal = OriginalReveal + "<html lang='de'>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "   <head>" + vbCrLf
OriginalReveal = OriginalReveal + "       <meta charset='utf-8'>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "       <title>StromDAO - #PPTName#</title>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "       <meta name='description' content='Exporter from Powerpoint to reveal'>" + vbCrLf
OriginalReveal = OriginalReveal + "       <meta name='author' content='Thorsten Zoerner'>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "       <meta name='apple-mobile-web-app-capable' content='yes'>" + vbCrLf
OriginalReveal = OriginalReveal + "       <meta name='apple-mobile-web-app-status-bar-style' content='black-translucent'>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "       <meta name='viewport' content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no, minimal-ui'>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "       <link rel='stylesheet' href='https://docs.stromdao.de/reveal.js/css/reveal.css'>" + vbCrLf
OriginalReveal = OriginalReveal + "       <link rel='stylesheet' href='https://docs.stromdao.de/reveal.js/css/theme/white.css' id='theme'>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "       <!-- Code syntax highlighting -->" + vbCrLf
OriginalReveal = OriginalReveal + "       <link rel='stylesheet' href='https://docs.stromdao.de/reveal.js/lib/css/zenburn.css'>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "       <link rel='stylesheet' href='https://docs.stromdao.de/slides.css'>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "       <!-- Printing and PDF exports -->" + vbCrLf
OriginalReveal = OriginalReveal + "       <script>" + vbCrLf
OriginalReveal = OriginalReveal + "           var link = document.createElement( 'link' );" + vbCrLf
OriginalReveal = OriginalReveal + "           link.rel = 'stylesheet';" + vbCrLf
OriginalReveal = OriginalReveal + "           link.type = 'text/css';" + vbCrLf
OriginalReveal = OriginalReveal + "           link.href = window.location.search.match( /print-pdf/gi ) ? 'https://docs.stromdao.de/reveal.js/css/print/pdf.css' : 'https://docs.stromdao.de/reveal.js/css/print/paper.css';" + vbCrLf
OriginalReveal = OriginalReveal + "           document.getElementsByTagName( 'head' )[0].appendChild( link );" + vbCrLf
OriginalReveal = OriginalReveal + "       </script>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "       <!--[if lt IE 9]>" + vbCrLf
OriginalReveal = OriginalReveal + "       <script src='https://docs.stromdao.de/reveal.js/lib/js/html5shiv.js'></script>" + vbCrLf
OriginalReveal = OriginalReveal + "       <![endif]-->" + vbCrLf
OriginalReveal = OriginalReveal + "   </head>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "   <body>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "       <div class='reveal'>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "           <div class='slides'>" + vbCrLf
OriginalReveal = OriginalReveal + "               #section#" + vbCrLf
OriginalReveal = OriginalReveal + "               " + vbCrLf
OriginalReveal = OriginalReveal + "               " + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "           </div>" + vbCrLf
OriginalReveal = OriginalReveal + "       </div>" + vbCrLf
OriginalReveal = OriginalReveal + "       <style>" + vbCrLf
OriginalReveal = OriginalReveal + "           /* Social sharing */" + vbCrLf
OriginalReveal = OriginalReveal + "           .share-reveal a {" + vbCrLf
OriginalReveal = OriginalReveal + "               display: inline-block;" + vbCrLf
OriginalReveal = OriginalReveal + "               height: 34px;" + vbCrLf
OriginalReveal = OriginalReveal + "               line-height: 32px;" + vbCrLf
OriginalReveal = OriginalReveal + "               padding: 0 10px;" + vbCrLf
OriginalReveal = OriginalReveal + "               color: #fff;" + vbCrLf
OriginalReveal = OriginalReveal + "               font-family: Helvetica, sans-serif;" + vbCrLf
OriginalReveal = OriginalReveal + "               text-decoration: none;" + vbCrLf
OriginalReveal = OriginalReveal + "               font-weight: bold;" + vbCrLf
OriginalReveal = OriginalReveal + "               font-size: 12px;" + vbCrLf
OriginalReveal = OriginalReveal + "               vertical-align: top;" + vbCrLf
OriginalReveal = OriginalReveal + "               text-transform: uppercase;" + vbCrLf
OriginalReveal = OriginalReveal + "               box-sizing: border-box;" + vbCrLf
OriginalReveal = OriginalReveal + "           }" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "           .share-reveal .share-reveal-editor {" + vbCrLf
OriginalReveal = OriginalReveal + "               line-height: 30px;" + vbCrLf
OriginalReveal = OriginalReveal + "           }" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "           .share-reveal svg {" + vbCrLf
OriginalReveal = OriginalReveal + "               vertical-align: middle;" + vbCrLf
OriginalReveal = OriginalReveal + "           }" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "           .share-reveal a + a {" + vbCrLf
OriginalReveal = OriginalReveal + "               margin-left: 10px;" + vbCrLf
OriginalReveal = OriginalReveal + "           }" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "           .share-reveal-editor {" + vbCrLf
OriginalReveal = OriginalReveal + "               border: 2px solid #fff;" + vbCrLf
OriginalReveal = OriginalReveal + "           }" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "           .share-reveal-twitter," + vbCrLf
OriginalReveal = OriginalReveal + "           .share-reveal-follow {" + vbCrLf
OriginalReveal = OriginalReveal + "               background-color: #00aced;" + vbCrLf
OriginalReveal = OriginalReveal + "           }" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "           .share-reveal-facebook {" + vbCrLf
OriginalReveal = OriginalReveal + "               background-color: #4B71B8;" + vbCrLf
OriginalReveal = OriginalReveal + "           }" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "           /* Advertising */" + vbCrLf
OriginalReveal = OriginalReveal + "           #carbonads {" + vbCrLf
OriginalReveal = OriginalReveal + "               width: 370px;" + vbCrLf
OriginalReveal = OriginalReveal + "               min-height: 100px;" + vbCrLf
OriginalReveal = OriginalReveal + "               font-size: 18px;" + vbCrLf
OriginalReveal = OriginalReveal + "               border: 1px solid rgba(255, 255, 255, 0.2);" + vbCrLf
OriginalReveal = OriginalReveal + "               padding: 10px;" + vbCrLf
OriginalReveal = OriginalReveal + "               margin: 40px auto 0 auto;" + vbCrLf
OriginalReveal = OriginalReveal + "               font-size: 16px;" + vbCrLf
OriginalReveal = OriginalReveal + "               z-index: 10;" + vbCrLf
OriginalReveal = OriginalReveal + "               text-align: left;" + vbCrLf
OriginalReveal = OriginalReveal + "           }" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "           #carbonads .carbon-img img {" + vbCrLf
OriginalReveal = OriginalReveal + "               float: left;" + vbCrLf
OriginalReveal = OriginalReveal + "               margin: 0 10px 0 0;" + vbCrLf
OriginalReveal = OriginalReveal + "               border: 0;" + vbCrLf
OriginalReveal = OriginalReveal + "               box-shadow: none;" + vbCrLf
OriginalReveal = OriginalReveal + "           }" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "           #carbonads .carbon-poweredby {" + vbCrLf
OriginalReveal = OriginalReveal + "               display: block;" + vbCrLf
OriginalReveal = OriginalReveal + "               margin-top: 10px;" + vbCrLf
OriginalReveal = OriginalReveal + "               color: #aaa;" + vbCrLf
OriginalReveal = OriginalReveal + "           }" + vbCrLf
OriginalReveal = OriginalReveal + "       </style>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "<script src='https://docs.stromdao.de/reveal.js/lib/js/head.min.js'></script>" + vbCrLf
OriginalReveal = OriginalReveal + "       <script src='https://docs.stromdao.de/reveal.js/js/reveal.js'></script>" + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "       <script>" + vbCrLf
OriginalReveal = OriginalReveal + "           // More info https://github.com/hakimel/reveal.js#configuration" + vbCrLf
OriginalReveal = OriginalReveal + "           Reveal.initialize({" + vbCrLf
OriginalReveal = OriginalReveal + "               history: true," + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "               // More info https://github.com/hakimel/reveal.js#dependencies" + vbCrLf
OriginalReveal = OriginalReveal + "               dependencies: [" + vbCrLf
OriginalReveal = OriginalReveal + "                   { src: 'https://docs.stromdao.de/reveal.js/plugin/markdown/marked.js' }," + vbCrLf
OriginalReveal = OriginalReveal + "                   { src: 'https://docs.stromdao.de/reveal.js/plugin/markdown/markdown.js' }," + vbCrLf
OriginalReveal = OriginalReveal + "                   { src: 'https://docs.stromdao.de/reveal.js/plugin/notes/notes.js', async: true }," + vbCrLf
OriginalReveal = OriginalReveal + "                   { src: 'https://docs.stromdao.de/reveal.js/plugin/highlight/highlight.js', async: true, callback: function() { hljs.initHighlightingOnLoad(); } }" + vbCrLf
OriginalReveal = OriginalReveal + "               ]" + vbCrLf
OriginalReveal = OriginalReveal + "           });" + vbCrLf
OriginalReveal = OriginalReveal + "       </script>       " + vbCrLf
OriginalReveal = OriginalReveal + "" + vbCrLf
OriginalReveal = OriginalReveal + "   </body>" + vbCrLf
OriginalReveal = OriginalReveal + "</html>" + vbCrLf
OriginalReveal = OriginalReveal + ""
End Function


