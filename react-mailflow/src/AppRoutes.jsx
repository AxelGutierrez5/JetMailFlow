import { useState } from 'react'
import { Routes, Route } from "react-router-dom";
import { DashboardPage } from './pages/dashboard'
import { Layout }  from './components/layout';
import { ContactsPage } from './pages/contacts'
import { Navigate } from 'react-router-dom';
import { Login } from './pages/login';

export function AppRoutes() {

  return (

    <Routes>
      
      <Route path="/" element={<Layout/>}>
        <Route index element={<Navigate to="dashboard" replace />} />
        <Route path="dashboard" element={<DashboardPage />} />
        <Route path='contacts' element={<ContactsPage/>}/>
      </Route>
      <Route path='/login' element={<Login/>} />

        
    </Routes>

  )

}


