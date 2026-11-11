# Municipal Services Application

A desktop application built using **C#**, **Windows Forms**, and **.NET Framework 4.8** to demonstrate municipal issue reporting, community event discovery, service-request tracking, and data-structure algorithms in a South African municipal-services context.

## Project Overview

The application was developed in three progressive parts:

- **Part 1 — Report Issues:** Citizens submit municipal service issues with a location, category, description, and optional attachment.
- **Part 2 — Local Events and Announcements:** Citizens browse, search, filter, and receive recommendations for community events.
- **Part 3 — Service Request Status:** Citizens look up submitted issues, view their status, inspect priority requests, and explore a demonstration municipal network using graph algorithms.

All three sections are accessible from the main menu.

## Features

### Part 1: Report Issues

The **Report Issues** screen lets users:

1. Enter the location of a municipal issue.
2. Choose a category, such as Roads and Potholes, Water and Sanitation, Electricity, Waste Collection, Street Lights, Traffic Lights, Public Facilities, or Other.
3. Describe the issue.
4. Optionally select a supporting JPG, JPEG, PNG, PDF, DOC, or DOCX file.
5. Submit the report after required-field validation.

The form displays progress feedback and guidance messages as fields are completed. On submission, it stores an `Issue` in the in-memory `IssueRepository`, displays the request's tracking ID, and resets the form for another report.

### Part 2: Local Events and Announcements

The **Local Events and Announcements** screen provides:

- A list of sample municipal and community events.
- Event details, including title, date, category, location, and description.
- Text searching across event information.
- Category filtering and an optional exact-date filter.
- An event recommendation feature based on the selected category or recorded category interest.

The `EventRepository` uses a `SortedDictionary<DateTime, List<MunicipalEvent>>` to group events by date, a `HashSet<string>` for unique categories, a `Queue<MunicipalEvent>` for event ordering, and a `Dictionary<string, int>` to track category interest.

**Sample-data note:** The included events have fixed dates from October and November 2026. Recommendations only consider events whose dates have not passed, so the sample dates may need updating when demonstrating the application later.

### Part 3: Service Request Status

The **Service Request Status** screen lets users:

- View submitted issues in a table.
- Search for a request using its tracking ID.
- Select a request to view its category, location, description, submission date, and status.
- See a progress indicator corresponding to the request's status.
- View the highest-priority request.
- Open the Municipal Network Analysis screen.

The status display supports the labels **Pending**, **In Progress**, **Under Review**, and **Resolved**. Newly submitted requests start in the pending state; the current application does not provide a separate administrative workflow for changing statuses.

### Municipal Network Analysis

The **Municipal Network Analysis** screen provides demonstrations of:

- **Breadth-First Search (BFS):** Visits connected locations level by level.
- **Depth-First Search (DFS):** Explores connected paths before backtracking.
- **Prim's Algorithm:** Constructs a minimum spanning tree for the weighted demonstration network and displays the total connection cost.

Users select a starting location and run an algorithm to see the results. The example network uses **Durban, Pinetown, Umhlanga, PMB, and Ballito**. Connections and weights are illustrative test data, **not live municipal routes, distances, or infrastructure costs**.

## Data Structures and Algorithms

| Structure or algorithm | Purpose in the application |
| --- | --- |
| `List<Issue>` | Holds reported issues during the current application session. |
| Binary Search Tree (`IssueBinarySearchTree`) | Organises requests by tracking ID. |
| AVL Tree (`IssueAVLTree`) | Provides balanced-tree lookup for tracking IDs. |
| Max-Heap (`IssueMaxHeap`) | Retrieves the highest-priority request. |
| `SortedDictionary` | Organises events by date. |
| `HashSet` | Stores unique event categories. |
| `Queue` | Stores events in insertion order. |
| `Dictionary` | Tracks user interest in event categories. |
| Adjacency-list graph (`MunicipalGraph`) | Represents connections for BFS and DFS. |
| Weighted graph (`MunicipalWeightedGraph`) | Represents weighted connections for Prim's algorithm. |

Priority values are assigned using `IssuePriorityHelper` according to issue category. These values are demonstration rules and do not represent an official municipal prioritisation policy.

## Technologies and Requirements

- C# and Windows Forms
- **.NET Framework 4.8**
- Microsoft Visual Studio with .NET desktop development support
- Windows computer capable of running .NET Framework 4.8 applications

Git and GitHub may be used for source control but are not required to run the downloaded project.

## Running the Application

1. Download or extract the project ZIP to a local folder.
2. Open the included Visual Studio solution (`.sln` or `.slnx`, depending on the project copy) or the `MunicipalServicesApp.csproj` project file.
3. If prompted, install the .NET Framework 4.8 targeting pack and Windows Forms development components.
4. Select **Build > Build Solution** in Visual Studio.
5. Press **F5** to run with debugging, or **Ctrl+F5** to run without debugging.
6. Use the main menu to open **Report Issues**, **Local Events and Announcements**, or **Service Request Status**.

### Suggested demonstration workflow

1. Open **Report Issues** and submit two or three issues in different categories. Keep their tracking IDs.
2. Open **Service Request Status**, search for those IDs, and select requests in the table to view their details.
3. Use the **View Highest Priority** feature to inspect the heap's highest-priority issue.
4. Open **Municipal Network Analysis** and compare BFS, DFS, and minimum spanning tree results from different starting locations.
5. Open **Local Events and Announcements** and try searching, category filtering, date filtering, and event recommendations.

## Project Organisation

Key source files include:

```text
MunicipalServicesApp/
├── Models/
│   ├── Issue.cs
│   └── MunicipalEvent.cs
├── Program.cs
├── MainMenuForm.cs
├── ReportIssueForm.cs
├── LocalEventsForm.cs
├── ServiceRequestStatusForm.cs
├── MunicipalNetworkForm.cs
├── IssueRepository.cs
├── EventRepository.cs
├── IssuePriorityHelper.cs
├── IssueBinarySearchTree.cs
├── IssueAVLTree.cs
├── IssueMaxHeap.cs
├── MunicipalGraph.cs
├── MunicipalWeightedGraph.cs
├── App.config
└── MunicipalServicesApp.csproj
```

Windows Forms designer files (`*.Designer.cs`) and resources accompany the corresponding forms.

## Validation and Testing

The application provides required-field validation when submitting reports and tracking-ID validation when searching. Invalid or missing request IDs produce user-facing feedback. Form navigation, event filtering, request details, priority lookup, BFS, DFS, and Prim's algorithm have been manually tested during development.

These are developer-reported functional tests; the README is not a substitute for an automated test suite or independent assessment.

## Current Limitations

- **In-memory storage:** Reports and event-interest history are not saved to a database or persistent file. Session data is lost when the application exits.
- **Attachments:** The application stores the selected attachment's file path; it does not copy or upload the file to a server.
- **Request IDs:** Tracking IDs are generated from the current number of stored requests. This is suitable for the present append-only demonstration but should be replaced with a more durable identifier strategy before adding deletion or persistent storage.
- **Request status:** There is no administrator interface or backend service to update request progress automatically.
- **Sample events:** Event data is predefined and some dates may be in the past.
- **Network analysis:** Graph connections and edge weights are fixed demonstration values.
- **Platform:** The application is a Windows desktop application, not a web or mobile service.

## Potential Future Enhancements

Possible extensions include persistent database storage, administrator workflows, file storage, user accounts, real municipal event feeds, and integration with live service-request systems. These are **not** part of the current implementation.

## Author

**Millennium Msomi**

Municipal Services Application — C# / .NET Framework / Windows Forms
