# PonderaWebDevTest
Initial put.

This is the developed solution for the "Web Developer Programming Test" given by Pondera.

A few things to note.

Had some issues with creating this environment. I initially wanted to use ASP.NET Core withing Visual Studio 2017 (Community Edition),
but I repeatedly ran into issues with the initial project - kept getting unexpected errors when attempting to download NuGet packages
within Visual Studio. It may be related to the fact that while I have the developer version of SQL Server 2017 installed, I have been
unable to get the SQL Server Management Studio (v17.2) to correctly function.

Anyway - given the above, I resorted to creating an ASP.NET MVC App (using .NET Framework 4.7).

Much of the code is created by the helpful wizards within Visual Studio.

The application, as it stands, has been published to http://ponderawebdevtest.azurewebsites.net

There's a small amount of data seeded, but running some initial tests against the Azure site is currently failing - not sure why at this 
time as this is my first exposure to publishing & testing via Azure deployment.

For instance actions/URLs that succeed locally are failing in the published app.

I'd like to spend more time on this, but I've already taken far too long in developing this small test that it's time to at least publish 
this. In a colaborative environment, I would have peers who I could consult for best practices and explain common issues.

This is the GitHub for this solution.
