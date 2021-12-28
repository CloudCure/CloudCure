# Guide to Cloud Cure setup

## How to setup Cloud Cure for development.

1. You need to install an IDE. Preferably Visual Studio Code or Visual Studio Community.
2. You need to install Node.js. The link to the install can be found at the URL https://nodejs.org/en/download/ This will also install NPM.
3. You need to clone the Cloud Cure repository using the following URL https://github.com/CloudCure/CloudCure OR download the repository onto your computer.

        git remote add origin https://github.com/CloudCure/CloudCure
4. Once you have cloned or downloaded the repository you will need to change directories to view and build the backend first to install the necessary packages. The following command will change your directory and run dotnet build on the backend.

        cd ./backend && dotnet build
5. After this you will need to cd back to the main CloudCure folder.

        cd ..
7. Then you will need to cd into the Cloudcure-Angular folder which is in the Frontend folder, and run the command npm install to get the required packages.

        cd ./Frontend/Cloudcure-Angular && npm install

11. Without changing folders you should now be able to enter the command "ng serve --open". This will compile the frontend and open a local version of the project in your browser.

        ng serve --open
## How to setup up Auth0.

1. Go to the website.
                https://auth0.com/
               
2. Create an account.
3. Go to applications tab.
4. Go through the quick start tab to setup your project.
5. Go to settings.
6. In the basic information section under settings you will find a domain and clientId. This information will be put in your app.module.ts under imports as shown in the picture below.

![alt text](https://i.imgur.com/4fNgJSy.jpg)
       
8. Scroll down on the settings page and put your localhost address and deployed website address in the boxes for allowed callback urls, allowed logout urls, and allowed web origins.
9. Go to the branding tab on the left side of the screen. Then go to universal login and here you can customize your html for the login screen.
## How to use Swagger to test your database.

1. Create a file in the WebAPI folder called appsettings.json. The WebAPI folder is located in the backend folder.

        cd ./backend/WebAPI && touch appsettings.json
3. In the appsettings.json file it should look similar to the picture below, except on the database row you will use your own connection string from Azure portal.

               {
                "Logging": {
                "LogLevel": {
                        "Default": "Information",
                        "Microsoft": "Warning",
                        "Microsoft.Hosting.Lifetime": "Information"
                 }
                },
                "AllowedHosts": "*",
                "ConnectionStrings": {
                  "database": "[Connection String Here]"
                }
               }

4. Go back to the backend directory

        cd ..
        
5. Make sure you WebAPI folder is added to the solution.

        dotnet sln add WebAPI
6. Once all of this is done you can press the green run IIS Express button at the top of Visual Studio Community. This will open your browser on the localhost and direct you to the Swagger page where you can test your database. If this doesnt immediately open up your browser you can open a new browser window and go to localhost:port/swagger/index.html
## EXAMPLE

    1. cd ./backend

    2. dotnet build
    
    3. cd ..
    
    4. cd ./Frontend
    
    5. cd ./Cloudcure-Angular
    
    6. npm install
