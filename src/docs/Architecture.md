# Architecture

## Projects

| Name                                | Purpose                                                    |
| ----------------------------------- | ---------------------------------------------------------- |
| PROJECT_IDENTIFIER.Core       | Xperience by Kentico generated content/data types and types shared across live site and administration          |
| PROJECT_IDENTIFIER.Admin      | Admin-only customizations to the Xperience by Kentico app |
| PROJECT_IDENTIFIER.Web        | Xperience by Kentico ASP.NET Core app    |
| PROJECT_IDENTIFIER.Web.Tests  | Unit and integration tests for PROJECT_IDENTIFIER.Web |
| PROJECT_IDENTIFIER.Web.E2E.Tests | End-to-end tests in Playwright.NET for PROJECT_IDENTIFIER.Web |

## Technologies and Frameworks

- `PROJECT_IDENTIFIER.Admin`
  - Webpack, React
- `PROJECT_IDENTIFIER.Web`
  - Vite.js, HTMX

## Integrations

### Google Tag Manager

The solution uses [Kentico.Xperience.TagManager](https://github.com/Kentico/xperience-by-kentico-tag-manager) to manage and load each environment's Google Tag Manager tag.

### Authentication

The site uses a custom Azure AD App Registration in the client-name tenant to provide SSO for client-name employees to the Xperience application. This integration is set up according to [the Xperience documentation](https://docs.kentico.com/developers-and-admins/configuration/users/administration-registration-and-authentication/administration-external-authentication#AdministrationExternalauthentication-MicrosoftAzureActiveDirectory) on the topic.

To assign Azure AD Users and Groups to specific roles within Xperience, manage the App Role assignments for the Enterprise Application.

Traditional Forms Authentication for the Admin is still enabled.
