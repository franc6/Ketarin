Different Behaviour on Linux
============================

The original version of Ketarin was written for the .NET environment. This is not available for Linux, but Mono is a close equivalent. Some behaviours, however, are different, and can't be fixed easily.

File->Export
------------
When you open the File menu and select one of the Export options, the Windows version lets you type the beginning of the path to the desired destination and then tap the Enter key. The program then displays the folders available at that point in the path. You can type part of a foldername and see options to choose with the arrow keys.

It seems this works in Windows because the function assumes you don't want to save the database into a file called *.XML*. The function in the Mono system on Linux, however, regards that as a normal filename, so a test for this has been added, and an error message appears.

In the Linux version it pays to explore to the desired destination with a command shell or a filesystem explorer, then copy the path to the clipboard. Then when you File->Export, paste the path into the *File Name* field and add the desired filename and tap Enter.

PageDown and PageUp
-------------------
In the Linux version, the PdDn key works as expected, but the PgUp key moves correctly only the first time you tap it. After that it moves up just a line each time.


When you click in the Page Down/Up area of the vertical scroll bar, the window scrolls, moving the slider all the way to where you clicked. This is called *warping* the slider. People say that this behaviour can be turned off by putting


    [Settings]
    gtk-primary-button-warps-slider = false
in ~/.config/gtk-3.0/settings.ini, but this doesn't seem to work.






