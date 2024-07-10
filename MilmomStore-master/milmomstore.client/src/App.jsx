import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Header from './Component/Header/Header';
import Register from './Page/Register/Register';

const App = () => {
    return (
        <Router>
            <Header />
            <Routes>
                <Route path="/register" element={<Register />} />
                {/* Add other routes here */}
            </Routes>
        </Router>
    );
};

export default App;
