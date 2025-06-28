import { useState } from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import Login from './components/Login';
import UserManagement from './components/UserManagement';

function App() {
  // Check for token in localStorage
  const [token, setToken] = useState(localStorage.getItem('token'));

  // Simple logout function
  const handleLogout = () => {
    localStorage.removeItem('token');
    setToken(null);
  };

  return (
    <Router>
      <div className="min-h-screen bg-gray-100">
        <Routes>
          <Route
            path="/login"
            element={
              <Login
                onLogin={(jwt) => {
                  setToken(jwt);
                  localStorage.setItem('token', jwt);
                }}
              />
            }
          />
          <Route
            path="/"
            element={
              token ? (
                <div>
                  <div className="bg-white shadow-sm border-b">
                    <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 flex justify-between items-center py-6">
                      <h1 className="text-2xl font-bold text-gray-900">PIM System</h1>
                      <button
                        onClick={handleLogout}
                        className="bg-red-500 text-white px-4 py-2 rounded hover:bg-red-600"
                      >
                        Logout
                      </button>
                    </div>
                  </div>
                  
                  <UserManagement />
                </div>
              ) : (
                <Navigate to="/login" replace />
              )
            }
          />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
