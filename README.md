# Personal Information Management System (PIM System)

A full-stack web application built with .NET 8 Web API backend and React frontend for managing user information with authentication and role-based access control.

## 🏗️ Architecture

- **Backend**: ASP.NET Core 8 Web API with Entity Framework Core
- **Database**: MySQL
- **Frontend**: React 18 with Vite
- **Styling**: Tailwind CSS
- **Icons**: Lucide React
- **Authentication**: JWT (JSON Web Tokens)
- **Password Security**: ASP.NET Core Identity Password Hasher

## 📁 Project Structure

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

## 🚀 Getting Started

### Prerequisites

- **.NET 8 SDK**
- **Node.js 18+**
- **MySQL Server**
- **Git**

### Backend Setup

1. **Clone the repository**
   ```bash
   git clone <repository-url>
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

## 🔌 API Endpoints

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

## 🔐 Authentication Flow

1. **User Registration**: Create account via POST `/api/user`
2. **User Login**: Authenticate via POST `/api/user/login`
3. **JWT Token**: Receive token for authenticated requests
4. **Protected Routes**: Frontend checks token for access control

## 🎨 Frontend Features

### Components
- **Login**: User authentication with form validation
- **UserManagement**: CRUD operations for user accounts
- **Protected Routes**: Role-based access control

### UI/UX
- **Responsive Design**: Works on desktop and mobile
- **Modern Styling**: Tailwind CSS with professional appearance
- **Loading States**: User feedback during API calls
- **Error Handling**: Graceful error messages

## 🛠️ Development

### Backend Development
```bash
cd PIMSys
dotnet watch run  # Hot reload for development
```

### Frontend Development
```bash
cd frontend
npm run dev  # Vite dev server with HMR
```

### Database Migrations
```bash
cd PIMSys
dotnet ef migrations add MigrationName
dotnet ef database update
```

## 🔧 Configuration

### Environment Variables
- **Database Connection**: Configure in `appsettings.json`
- **JWT Secret**: Set `TokenKey` in `appsettings.json`
- **CORS**: Configured for React app on port 3000

### Build Configuration
- **Backend**: .NET 8 with Entity Framework Core
- **Frontend**: Vite with React 18
- **Database**: MySQL with Pomelo.EntityFrameworkCore.MySql

## 🧪 Testing

### API Testing
Use tools like Postman or curl to test endpoints:
```bash
# Create user
curl -X POST https://localhost:5143/api/user \
  -H "Content-Type: application/json" \
  -d '{"name":"John Doe","email":"john@example.com","password":"password123"}'

# Login
curl -X POST https://localhost:5143/api/user/login \
  -H "Content-Type: application/json" \
  -d '{"email":"john@example.com","password":"password123"}'
```

## 📦 Dependencies

### Backend (.NET)
- ASP.NET Core 8
- Entity Framework Core
- AutoMapper
- Microsoft.AspNetCore.Identity
- Pomelo.EntityFrameworkCore.MySql
- System.IdentityModel.Tokens.Jwt

### Frontend (React)
- React 18
- Vite
- Tailwind CSS
- Lucide React
- React Router DOM

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License.

## 🆘 Troubleshooting

### Common Issues

1. **Database Connection Error**
   - Verify MySQL is running
   - Check connection string in `appsettings.json`
   - Ensure database exists

2. **JWT Token Error**
   - Verify `TokenKey` is set in `appsettings.json`
   - Ensure key is at least 64 characters long

3. **CORS Error**
   - Backend CORS is configured for `http://localhost:3000`
   - Frontend proxy is set to `http://localhost:5143`

4. **Tailwind CSS Not Working**
   - Ensure PostCSS configuration is correct
   - Check that Tailwind directives are in `index.css`

## 🔮 Future Enhancements

- [ ] Role-based access control (Admin/User roles)
- [ ] User profile management
- [ ] Password reset functionality
- [ ] Email verification
- [ ] Audit logging
- [ ] API rate limiting
- [ ] Unit and integration tests
