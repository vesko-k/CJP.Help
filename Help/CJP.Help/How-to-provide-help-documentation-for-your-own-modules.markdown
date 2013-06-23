It's easy to provide documentation for your own modules, and there are a couple of different ways to do it. This page outlines both methods you can use, and when you should use each method over another.

#Markdown files

The simplest way to document your module is by creating a Help folder and placing markdown documents into it. The Help module will then discover each document and inject them into the front end.

In order for the Help module to be able to discover your documentation, you must create a folder called `Help` in the root of your module and then you should create another folder in the `Help` folder for each feature you want to document.