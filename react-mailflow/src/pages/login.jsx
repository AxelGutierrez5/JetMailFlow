import { NavLink } from "react-router-dom"
import { InputPersonalize } from "../components/input"
import { useState } from "react"
const url = "https://localhost:7211/api/usuario/login"
import { AlertError } from "../components/AlertError"
import { useNavigate } from "react-router-dom";

export function LoginPage(){

    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const [visibleErrors, setVisibleErrors] = useState(false)
    const [errorsList, setErrorsList] = useState([]);
    const navigate = useNavigate()



    const handleOnChangeEmail = (e)=> setEmail(e.target.value)
    const handleOnChangePassword = (e)=> setPassword(e.target.value) 

    const handleOnSubmit = (e) => {

        e.preventDefault();
        sendCredentials(email,password)

    }


    const sendCredentials =async (emailInput, passwordInput)=>{

        

        try{
            
            setErrorsList([])
            setVisibleErrors(false)

            const response =await fetch(url,{

                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    email: emailInput,
                    password: passwordInput
                })
                
            })
            let data = await response.json()

            if(response.ok) {

                if(data.success){
                    alert(data.message)
                    navigate("/dashboard")  
                }
                else{

                    setErrorsList(data.value)
                    setVisibleErrors(true)
                }
            }
            else{
                setErrorsList(data.value)
                setVisibleErrors(true)
            }

        }
        catch(error)
        {

            setErrorsList([error.message]);
            setVisibleErrors(true);

        }

       



    }

   

    return(
    
    <div className="h-screen flex justify-center items-center">
        <div className="bg-slate-800 p-8 rounded-xl shadow-2xl w-full max-w-md border border-slate-700">
            <div className="text-center mb-8">
                <div className="inline-flex items-center justify-center w-12 h-12 rounded-lg bg-indigo-500/10 text-indigo-500 mb-4 border border-indigo-500/20">
                    <i className='bx bxs-paper-plane text-2xl'></i>
                </div>
                <h1 className="text-2xl font-bold text-white">Bienvenido a JetMailFlow</h1>
                <p className="text-slate-400 mt-2">Inicia sesión para continuar</p>
            </div>
            
            <form onSubmit={handleOnSubmit}>
                <div className="mb-4">
                    <label className="block text-sm font-medium text-slate-400 mb-2">Correo Electrónico</label>
                    <div className="relative">
                        <span className="absolute inset-y-0 left-0 pl-3 flex items-center text-slate-500"><i className='bx bxs-envelope'></i></span>
                        <input type="email" onChange={handleOnChangeEmail} className="w-full bg-slate-900 border border-slate-700 rounded-lg pl-10 pr-4 py-3 text-white focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 transition-colors" placeholder="Ej: Juan12@gmail.com" required/>
                    </div>
                </div>
                <div className="mb-6">
                    <label className="block text-sm font-medium text-slate-400 mb-2">Contraseña</label>
                    <div className="relative">
                        <span className="absolute inset-y-0 left-0 pl-3 flex items-center text-slate-500"><i className='bx bxs-lock-alt'></i></span>
                        <input type="password" onChange={handleOnChangePassword} className="w-full bg-slate-900 border border-slate-700 rounded-lg pl-10 pr-4 py-3 text-white focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 transition-colors" placeholder="••••••••" required/>
                    </div>
                    <div className="flex justify-between mt-2">
                
                        <NavLink to="/register" className="text-xs text-indigo-400 hover:text-indigo-300" >Crear cuenta ahora</NavLink>
                        <NavLink to="/forgotpassword" className="text-xs text-indigo-400 hover:text-indigo-300">¿Olvidaste tu contraseña?</NavLink>
                    </div>
                </div>

                {visibleErrors && <AlertError errors={errorsList}/>}

                <button type="submit" id="btn-login" className="w-full bg-indigo-600 hover:bg-indigo-500 text-white font-bold py-3 rounded-lg transition-all shadow-lg shadow-indigo-500/20">
                    Iniciar Sesión
                </button>
            </form>
        </div>



    </div>)


}

