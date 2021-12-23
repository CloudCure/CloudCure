## Guide to Cloud Cure setup

The easiest way to setup Cloud Cure for development is to follow the steps below.

1. You need to install an IDE. Preferably Visual Studio Code or Visual Studio Community.
2. You need to install Node.js. The link to the install can be found at the URL https://nodejs.org/en/download/ This will also install NPM
3. You need to clone the Cloud Cure repository using git clone using URL https://github.com/CloudCure/CloudCure OR download the repository onto your computer.
4. Once you have cloned or downloaded the repository you will need to change directories to view and build the backend first to install the necessary packages. The following command will change your directory and run dotnet build on the backend.

        cd .\backend && dotnet build
7. After this you will need to cd back to the main CloudCure folder. To do this please run "cd ..". The third example will show you how the command should look.
8. Then you will need to cd into the Frontend folder using the command in example 4.
9. Then you will need to cd into the Cloudcure-Angular folder.
10. Next enter the command "npm install" as seen in example 6. This will install the packages needed for the frontend.
11. Without changing folders you should now be able to enter the command "ng serve" as seen in example 7. This will compile the frontend and allow you to view a local version of the project. To access this page open your web browser and enter the URL http://localhost:4200/ this should let you view your project.



## EXAMPLE

    1. cd .\backend

    2. dotnet build
    
    3. cd ..
    
    4. cd .\Frontend
    
    5. cd .\Cloudcure-Angular
    
    6. npm install
