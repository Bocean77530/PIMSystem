# Personal Information Management System (PIM System)

A full-stack web application built with .NET 8 Web API backend and React frontend for managing user information with authentication and role-based access control.

## Table of Contents
- [Introduction](#introduction)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Getting Start](#getting-started)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)
- [Future Enhancements](#future-enhancements)

## Introduction

This demo project shows how a frontend can smoothly work with a backend. It’s built with a clean, scalable structure that follows SOLID principles, so it’s easy to add new features without digging through complicated code. For security, it uses JWT for authentication and hashes user passwords. The frontend and backend are connected through well-organised API calls, making data flow clear and reliable. Feel free to explore the project, try it out, and use it as a learning tool for building secure and maintainable full-stack apps.

### Components
- **Login**: User authentication with form validation
- **UserManagement**: CRUD operations for user accounts
- **Protected Routes**: Role-based access control

### UI/UX
- **Responsive Design**: Works on desktop and mobile
- **Modern Styling**: Tailwind CSS with professional appearance
- **Loading States**: User feedback during API calls
- **Error Handling**: Graceful error messages

### Authentication Flow

1. **User Registration**: Create account via POST `/api/user`
2. **User Login**: Authenticate via POST `/api/user/login`
3. **JWT Token**: Receive token for authenticated requests
4. **Protected Routes**: Frontend checks token for access control

## Architecture

- **Backend**: ASP.NET Core 8 Web API with Entity Framework Core
- **Database**: MySQL
- **Frontend**: React 18 with Vite
- **Styling**: Tailwind CSS
- **Icons**: Lucide React
- **Authentication**: JWT (JSON Web Tokens)
- **Password Security**: ASP.NET Core Identity Password Hasher

## Project Structure

```
PIMSystem/
├── PIMSys/                    # .NET Backend
│   ├── Controllers/           # API Controllers
│   ├── Data/                  # Database Context
│   ├── DTOs/                  # Data Transfer Objects
│   ├── Models/                # Entity Models
│   ├── Services/              # Business Logic
│   ├── Repositories/          # Data Access Layer
│   ├── Mappers/               # AutoMapper Profiles
│   └── Migrations/            # Database Migrations
├── frontend/                  # React Frontend
│   ├── src/
│   │   ├── components/        # React Components
│   │   └── App.jsx           # Main App Component
│   └── package.json
└── README.md
```

## Getting Started

### Prerequisites

- **.NET 8 SDK**
- **Node.js 18+**
- **MySQL Server**
- **Git**

### Backend Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/Bocean77530/PIMSystem.git
   cd PIMSystem
   ```

2. **Configure Database**
   - Update connection string in `PIMSys/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "server=localhost;database=mydb;user=root;password=your_password;"
     }
   }
   ```

3. **Add JWT Token Key**
   - Add to `PIMSys/appsettings.json`:
   ```json
   {
     "TokenKey": "your-very-long-random-secret-key-at-least-64-characters-long-1234567890abcdef1234567890abcdef"
   }
   ```

4. **Install Dependencies & Run Migrations**
   ```bash
   cd PIMSys
   dotnet restore
   dotnet ef database update
   ```

5. **Run the Backend**
   ```bash
   dotnet run
   ```
   The API will be available at `https://localhost:5143`

### Frontend Setup

1. **Install Dependencies**
   ```bash
   cd frontend
   npm install
   ```

2. **Start Development Server**
   ```bash
   npm run dev
   ```
   The frontend will be available at `http://localhost:3000`

## API Endpoints

### Authentication
- `POST /api/user/login` - User login
  - **Body**: `{ "email": "string", "password": "string" }`
  - **Returns**: JWT token

### User Management
- `GET /api/user` - Get all users
- `GET /api/user/{id}` - Get user by ID
- `POST /api/user` - Create new user
  - **Body**: `{ "name": "string", "email": "string", "password": "string" }`
- `DELETE /api/user/{id}` - Delete user

## Contributing

1. Fork the repository
2. Create a feature branch(`git checkout -b feature/AmazingFeature`)
3. Make your changes(`git commit -m 'Add some AmazingFeature'`)
4. Add tests if applicable(`git push origin feature/AmazingFeature`)
5. Submit a pull request

## License

This project is licensed under the [MIT License](LICENSE).

## Future Enhancements

- [ ] Role-based access control (Admin/User roles)
- [ ] User profile management
- [ ] Password reset functionality
- [ ] Email verification
- [ ] Audit logging
- [ ] API rate limiting
- [ ] Unit and integration tests
