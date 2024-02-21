# Xperience Community - Xperience by Kentico .NET CLI Template

This repository contains the source used by the Xperience Community Xperience by Kentico .NET CLI templates

## Build and Install Locally

Ensure [Windows 10 long file paths](https://www.howtogeek.com/266621/how-to-make-windows-10-accept-file-paths-over-260-characters/) is enabled

To build the NuGet package locally:

    dotnet pack .\XperienceCommunity.SolutionTemplate.csproj --version-suffix "preview.X" -o ./nupkg

To install the tool (replacing `-previewX` with the version specified in the `.nuspec` file):

    dotnet new --install .\nupkg\XperienceCommunity.SolutionTemplate.nuspec.1.0.0-preview.X.nupkg

To use the template, create a new directory:

    > mkdir PROJ01
    > cd PROJ01

Then run the template:

    dotnet new xpc-xperience-by-kentico-sln --name PRO01 --ClientName pro-client

To uninstall the template, run:

    dotnet new --uninstall XperienceCommunity.SolutionTemplate

## Install from NuGet

Run the following to install the pre-release template from NuGet:

    dotnet new install XperienceCommunity.SolutionTemplate::<version-number>

Where `<version-number>` is replaced by the [latest pre-release version number](NUGET_URL)

To install the latest full release version of the template, run the following:

    dotnet new install XperienceCommunity.SolutionTemplate

- See more on installing [.NET CLI project/solution templates](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates#installing-a-template-package)

## Use the Template

Execute the following at the command line at the root of the repository you would like to contain the Xperience by Kentico project (where `PRO01` is the project identifier and `pro-client` is the client's name in lowercase):

     dotnet new xpc-xperience-by-kentico-sln --name PRO01 --ClientName pro-client

> Note: You can specify the `-o` option to create an output folder. If you don't specify an output folder, all the files will be generated in the folder in which you execute the `dotnet new` command.

There are other options that can be specified with the template. These will be listed when using the `--help` option:

    dotnet new xpc-xperience-by-kentico-sln --help

If you experience strange issues where it seems like updates to the template aren't applied when you use the template, clear the template cache for your current runtime:

    rm ~\.templateengine\dotnetcli\<your-runtime>\templatecache.json

## Resources

<https://github.com/dotnet/templating/wiki/Available-Symbols-Generators>

<https://github.com/dotnet/templating/issues/2210#issuecomment-692630534>

<https://github.com/dotnet/aspnetcore/tree/main/src/ProjectTemplates>

<https://github.com/dotnet/dotnet-template-samples>

<https://github.com/sayedihashimi/template-sample>
