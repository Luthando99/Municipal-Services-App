# Municipal Services Application

A C# Windows Forms application developed to provide citizens with a simple and user-friendly way to interact with municipal services.

This repository currently contains **Part 1** of the Municipal Services Application, which focuses on allowing users to report municipal issues such as potholes, water problems, electricity faults, waste collection issues, damaged public facilities, and other service-related concerns.

---

## Project Overview

The Municipal Services Application is designed around a South African municipal service-delivery context.

Part 1 introduces the **Report Issues** feature. Citizens can provide information about a municipal problem, select the appropriate category, describe the issue, and optionally attach supporting evidence.

The application also incorporates user-engagement features such as progress feedback and contextual messages to guide users through the reporting process.

---

## Current Features

### Main Menu

The application provides a central navigation screen containing:

- Report Issues
- Local Events and Announcements
- Service Request Status

For Part 1, **Report Issues** is active.

The Local Events and Announcements and Service Request Status options are displayed but disabled because they will be implemented in later parts of the project.

### Report an Issue

Users can submit a municipal issue by providing:

- Location
- Issue category
- Description of the problem
- Optional supporting evidence

Available categories include:

- Roads and Potholes
- Water and Sanitation
- Electricity
- Waste Collection
- Street Lights
- Traffic Lights
- Public Facilities
- Other

### Supporting Evidence

Users can optionally attach supporting documentation relating to the reported issue.

Supported file types include:

- JPG / JPEG
- PNG
- PDF
- DOC
- DOCX

The selected filename is displayed on the form before the report is submitted.

### User Engagement and Progress Feedback

The application includes a progress bar that responds as the user completes the report.

Contextual messages guide the user through the process, for example:

> Let's get started! Tell us where the issue is.

> Great start! Now choose the type of issue.

> You're halfway there! Please describe the problem.

> Almost done! You may attach supporting evidence.

> Excellent! Your report is ready to submit.

This provides immediate feedback and makes the reporting process easier to follow.

### Input Validation

The application validates required information before accepting a report.

The following fields are required:

- Location
- Category
- Description

Supporting evidence is optional.

Users receive appropriate feedback when required information has not been provided.

### Report Storage

Submitted reports are represented using an `Issue` model and stored during runtime using an in-memory collection managed by `IssueRepository`.

Each report contains information such as:

- Location
- Category
- Description
- Attachment path
- Date reported

After a successful submission, the application confirms that the issue has been stored and resets the reporting form for another submission.

---

## Technologies Used

- C#
- .NET Framework
- Windows Forms
- Visual Studio
- Git
- GitHub

---

## Project Structure

```text
MunicipalServicesApp/
│
├── MunicipalServicesApp.slnx
├── .gitignore
├── README.md
│
└── MunicipalServicesApp/
    ├── Models/
    │   └── Issue.cs
    │
    ├── IssueRepository.cs
    ├── MainMenuForm.cs
    ├── MainMenuForm.Designer.cs
    ├── ReportIssueForm.cs
    ├── ReportIssueForm.Designer.cs
    ├── Program.cs
    ├── App.config
    └── MunicipalServicesApp.csproj
```

Generated Visual Studio folders such as `.vs`, `bin`, and `obj` are excluded from the repository using `.gitignore`.

---

## How to Run the Application

### Requirements

To open and run the project, you will need:

- Windows
- Visual Studio
- .NET Framework development support

### Running the Project

1. Clone or download this repository.
2. Open `MunicipalServicesApp.slnx` in Visual Studio.
3. Allow Visual Studio to restore/load the project.
4. Build the solution.
5. Run the application using **Start** or press `F5`.

The Municipal Services main menu will open.

Select **Report Issues** to access the issue-reporting functionality.

---

## Using the Report Issues Feature

1. Enter the location of the municipal issue.
2. Select an appropriate issue category.
3. Describe the problem.
4. Optionally attach supporting evidence.
5. Follow the progress indicator and guidance messages.
6. Click **Submit**.
7. The application validates the information and stores the report.
8. A confirmation message is displayed after successful submission.

The **Back** button returns the user to the main menu.

---

## Data Storage

Part 1 currently uses **in-memory storage**.

This means submitted reports remain available while the application is running but are not permanently stored after the application is closed.

Persistent storage may be introduced as the application is expanded.

---

## Current Limitations

This repository currently represents **Part 1** of the application.

Therefore:

- Local Events and Announcements is not yet implemented.
- Service Request Status is not yet implemented.
- Reports are stored only in memory.
- There is currently no database or permanent file-based storage.
- The application is currently designed as a Windows desktop application.

---

## Planned Development

Future development of the Municipal Services Application will introduce additional functionality.

### Part 2 — Local Events and Announcements

The application will be expanded to provide access to local events and municipal announcements.

This phase will introduce additional data structures and functionality for organising, searching, and recommending information.

### Part 3 — Service Request Status

The final phase will introduce functionality for tracking municipal service requests.

This phase will expand the application through more advanced data structures and service-request management functionality.

---

## User Interface

The application has been designed with usability and simplicity in mind.

Part 1 provides:

- Clear navigation
- Consistent form controls
- User-friendly validation
- Responsive progress feedback
- Contextual guidance
- File attachment support
- Confirmation messages
- Simple navigation between application screens

---

## Development Status

**Part 1 — Report Issues: COMPLETE ✅**

**Part 2 — Local Events and Announcements: Planned**

**Part 3 — Service Request Status: Planned**

---

## Repository Notes

Visual Studio-generated development files and build outputs are excluded through `.gitignore`.

This keeps the repository focused on the source code and files required to build and understand the application.

---

## Author

**Luthando Mtolo**

Municipal Services Application  
C# / .NET Framework / Windows Forms