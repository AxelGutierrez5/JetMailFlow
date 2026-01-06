import { useState } from 'react'
import { Routes, Route } from "react-router-dom";
import { DashboardPage } from './pages/dashboard'
import { Layout }  from './components/layout';
import { ContactsPage } from './pages/contacts/contacts'
import { Navigate } from 'react-router-dom';
import { LoginPage } from './pages/login';
import { CampaniaPage } from './pages/campaings';
import { Settings } from './pages/settings';
import { RegisterPage } from './pages/register';
import { ForgotPasswordPage } from './pages/forgotPassword';

export function AppRoutes() {

  return (

    <Routes>
      
      <Route path="/" element={<Layout/>}>
        <Route index element={<Navigate to="dashboard" replace />} />
        <Route path="dashboard" element={<DashboardPage />} />
        <Route path='contacts' element={<ContactsPage/>}/>
        <Route path='campaigns' element={<CampaniaPage/>}/>
        <Route path='settings' element={<Settings/>}/>

      </Route>
      <Route path='/login' element={<LoginPage/>} />
      <Route path='/register' element={<RegisterPage/>}/>
      <Route path='/forgotpassword' element={<ForgotPasswordPage/>}/>
      
    </Routes>

  )

}


