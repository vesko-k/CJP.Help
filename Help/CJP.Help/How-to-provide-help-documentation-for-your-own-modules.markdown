It's easy to provide documentation for your own modules, and there are a couple of different ways to do it. This page outlines both methods you can use, and when you should use each method over another.

#Markdown files

The simplest way to document your module is by creating a Help folder and placing markdown documents into it. The Help module will then discover each document and inject them into the front end.  


In order for the Help module to be able to discover your documentation, you must create a folder called `Help` in the root of your module and then you should create another folder in the `Help` folder for each feature you want to document.
You can then put as many `.markdown` files into each of these folders as you need. The filename should be how you want the title of the document to appear (you should replace spaces with dashes (-) so that the urls appear friendlier).


For example, the markdown file for this page is located in:

	~/Models/CJP.Help/Help/CJP.Help/How-to-provide-help-documentation-for-your-own-modules.markdown

If I were to create a second feature within this module and call it `My.New.Feature`, I could place the markdown files for that feature as follows:

    ~/Modules/CJP.Help/Help/My.New.Feature/Help-File-1.markdown
    ~/Modules/CJP.Help/Help/My.New.Feature/Help-File-2.markdown

This folder structure allows for help pages to be hidden or visible based on features that have actually been enabled.

#Extensibility Points
Placing `.markdown` files into your modules is a great way of providing documentation for it. However, there may be times when you need to extend the documentation for module that isn't yours, or you may want to gain finer control of your documentation and leverage some of the more powerful features of this module. Lets find out how we can do this:

If you are reading the `.markdown` file for this page, you will find that it ends here.  

