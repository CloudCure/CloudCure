## Guide to Cloud Cure setup

The easiest way to setup Cloud Cure for development is to follow the steps below.

1. You need to install an IDE. Preferably Visual Studio Code or Visual Studio Community.
2. You need to install Node.js. The link to the install can be found at the URL https://nodejs.org/en/download/ This will also install NPM
3. You need to clone the Cloud Cure repository using git clone using URL https://github.com/CloudCure/CloudCure OR download the repository onto your computer.
4. Once you have cloned or downloaded the repository you will need to change directories to view the backend first. The first example will show you the command for this.
5. Once you have CD (change directory) into the backend you will need to then run dotnet build to install the necessary packages. The second example will show you the command for this.
6. After this you will need to cd back to the main CloudCure folder. To do this please run "cd ..". The third example will show you how the command should look.
7. Then you will need to cd into the Frontend folder using the command in example 4.
8. Then you will need to cd into the Cloudcure-Angular folder.
9. Next enter the command "npm install" as seen in example 6. This will install the packages needed for the frontend.
10. Without changing folders you should now be able to enter the command "ng serve" as seen in example 7. This will compile the frontend and allow you to view a local version of the project. To access this page open your web browser and enter the URL http://localhost:4200/ this should let you view your project.



## EXAMPLE

    1. cd .\backend

    2. dotnet build
    
    3. cd ..
    
    4. cd .\Frontend
    
    5. cd .\Cloudcure-Angular
    
    6. npm install
