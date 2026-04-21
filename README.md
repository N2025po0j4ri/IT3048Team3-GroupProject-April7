Conference Companion: Agenda Manager Mobile App
📌 Project Overview

Conference Companion is a mobile application built using .NET MAUI that helps users efficiently manage and navigate a 2-day conference schedule. The app replaces traditional printed agendas with an interactive, customizable, and portable solution.

🎯 Project Goals
Provide a clean, user-friendly interface for viewing conference schedules
Allow users to bookmark and manage favorite sessions
Enable fast searching and filtering of sessions
Ensure offline access to agenda data
Deliver a responsive experience across Android and Windows platforms
Practice collaborative development using GitHub workflows
👥 Team Members
Front End Developer: Addyson Beecham
Back End Developer: Nirupama Poojari
Team Lead: Miles Cresci
UI Specialist: Levi
🚀 Features
2-Day Agenda View
Session Details Page
Favorites / Bookmarking
Search & Filter Functionality
Optional Notifications & Reminders
Offline Data Access
Cross-platform UI (Android & Windows)
Shell-based Navigation
🛠️ Technology Stack
.NET MAUI
C#
XAML
Local Storage (Preferences / SQLite if extended)
⚙️ How to Access the Project
1. Clone the Repository

Open your terminal or Git Bash and run:

git clone https://github.com/N2025po0j4ri/IT3048Team3-GroupProject-April7.git
cd conference-companion-maui

2. Open the Project
Launch Visual Studio (2022 or later recommended)
Click "Open a project or solution"
Select the .sln file from the cloned repository
3. Restore Dependencies
Visual Studio should automatically restore dependencies
If not, run:
dotnet restore
4. Build the Application
dotnet build

Or use:

Build → Build Solution inside Visual Studio
5. Run the Application
Option A: Using Visual Studio (Recommended)
Select target device:
Android Emulator
Windows Machine
Click Run (▶️)
Option B: Command Line
dotnet build -t:Run
📂 Project Structure (Example)
/ConferenceCompanion
 ├── Models/
 ├── Views/
 ├── ViewModels/
 ├── Services/
 ├── Resources/
 ├── AppShell.xaml
 └── MauiProgram.cs
🔄 GitHub Workflow (Team Process)
Branching Strategy
main → stable production-ready code
develop → integration branch
feature/* → individual features

Example:

feature/agenda-view
feature/favorites
feature/search-filter
Making Changes
Pull latest updates:
git pull origin develop
Create a new branch:
git checkout -b feature/your-feature-name
Commit changes:
git add .
git commit -m "Added: session bookmarking feature"
Push branch:
git push origin feature/your-feature-name
Pull Requests
Open a PR into develop
Add a clear description of changes
Request at least 1 review before merging
✅ Expected Outcomes
Fully functional agenda management app
Clean, intuitive UI/UX
Reliable navigation and data handling
Strong team collaboration using GitHub
Completion within the 7-week timeline
⚠️ Known Challenges & Solutions

Challenge: Team coordination

✅ Solution: Weekly check-ins + defined roles

Challenge: Merge conflicts

✅ Solution: Frequent pulls + small commits

Challenge: Feature integration

✅ Solution: Use develop branch for testing before merging to main
📌 Future Enhancements
Cloud sync for multiple devices
User authentication
Real-time schedule updates
Push notifications
