---
title: "How I Use VS Code to Maintain/Develop Hugo"
subtitle: ""
date: 2021-01-16T02:45:31-05:00
lastmod: 2021-01-16T02:45:31-05:00
draft: false
author: ""
authorLink: ""
description: "A brief description of the development environment I have setup for Hugo."

tags: [Hugo]
categories: [Development]

hiddenFromHomePage: false
hiddenFromSearch: false

featuredImage: ""
featuredImagePreview: "vscode-tasks-preview.png"
toc:
  enable: true
math:
  enable: false
lightgallery: true
license: ""
---
<!--more-->
VS Code is paving the way when it comes to extensibility in your IDE. Below is a short summary of the plugins and tasks I use to make working on this blog slightly easier.

## Plugins
* **Better TOML:** https://marketplace.visualstudio.com/items?itemName=bungcip.better-toml  
  * This plugin assists with editing some of the potentially massive `config.toml` files present in the Hugo ecosystem.  
* **Markdown Preview Enhanced:** https://marketplace.visualstudio.com/items?itemName=shd101wyy.markdown-preview-enhanced  
  * As stated, with this plugin it becomes possible to preview, in real-time, the written markdown within VS Code. It doesn't have the ability to preview Hugo's shortcodes, so you'll still need to refresh there, but it's good for catching basic markdown syntax errors.

  {{< image src="markdown-preview.png" caption="Markdown Preview to the Right" >}}
* **Paste Image:** https://marketplace.visualstudio.com/items?itemName=mushan.vscode-paste-image  
  * My personal favorite - Paste Image allows you to paste an image, straight from your clipboard, into VS Code. It can save the imave to the same directory as the file you're editing, and if you have text highlighted, give it an appropriate filename _and_ markdown syntax. [See it in action here.](https://gfycat.com/ripenearant)

## Tasks
The below JSON document represents my current `${workspaceFolder}.vscode/tasks.json`, commented for your convenience. With the Task menu bound to `Alt+R`, it's simple to execute each task. Included is a mini-CD "pipeline" that allows me to deploy my changes to build and deploy in one task.  
{{< admonition note>}}
I've left out the `tasks[].presentation` property for brevity, but it should have no bearing on the execution of these tasks.  
For best results, place your `hugo.exe` in the same folder as your VS Code workspace, and add it to your .gitignore
{{< /admonition >}}
```json
{
  // See https://go.microsoft.com/fwlink/?LinkId=733558
  // for the documentation about the tasks.json format
  "version": "2.0.0",
  "tasks": [
      {   // Builds the website, outputting the resultant files in the /public directory
          "label": "Build Hugo Site",
          "type": "shell",
          "command": "${workspaceFolder}/hugo.exe -s ${workspaceFolder}/SvenAiBlog -e production",
          "problemMatcher": []
      },
      {   // Creates a new post, utilizing VS Code's input system to name the post
          "label": "Create New Hugo Post",
          "type": "shell",
          "command": "${workspaceFolder}/hugo.exe new posts/${input:postName}/index.md -s ${workspaceFolder}/SvenAiBlog ",
          "problemMatcher": []
      },
      {   // Starts the server
          "label": "Start Hugo Server (Development)",
          "type": "shell",
          "command": "${workspaceFolder}/hugo.exe server -s ${workspaceFolder}/SvenAiBlog",
          "problemMatcher": []
      },
      {   // Starts the server in production
          "label": "Start Hugo Server (Production)",
          "type": "shell",
          "command": "${workspaceFolder}/hugo.exe server -s ${workspaceFolder}/SvenAiBlog -e production",
          "problemMatcher": []
      },
      {   // Combines the build step with an automated move, commit, and push.
          // Note the input that allows me to specify the commit message.
          "label": "Build & Deploy Blog",
          "type": "shell",
          "command": "cp -force -recurse ${workspaceFolder}/SvenAiBlog/public/* D:/svengeance.github.io/; cd D:/svengeance.github.io;git add -A ;git commit -m '${input:commitMessage}';git push",
          "dependsOrder": "sequence",
          "dependsOn": ["Build Hugo Site"],
          "problemMatcher": []
      },
      {   // Kills all running tasks. Can impact outside of Hugo.
          "label": "Terminate All Tasks",
          "command": "echo ${input:terminate}",
          "type": "shell",
          "problemMatcher": []
        }
  ],
  "inputs": [
      {
          "id": "postName",
          "description": "Name of the new post",
          "type": "promptString",
          "default": "new-post"
      },
      {
          "id": "commitMessage",
          "description": "Enter commit message",
          "type": "promptString",
          "default": "Updates Blog"
      },
      {
          "id": "terminate",
          "type": "command",
          "command": "workbench.action.tasks.terminate",
          "args": "terminateAll"
        }
    ]
}
```

## Summary
By utilizing the new-post creation and server-start, I've got a blank slate to start writing. I typically use the markdown preview as I write, and only check Hugo on my browser when verifying I've correctly used the shortcodes (Youtube/Discord otherwise). If I've done something new or different that I want to verify before pushing live, I will build the site and copy the files manually to observe any differences. Short of anything new, I'll simply run the build & deploy script.

-------------------------
Have any better ideas? Let me know in the comments -- always looking to improve.