import { useState } from "react"
import { NavLink } from "react-router-dom"
import { useNavigate } from "react-router-dom"
import { AlertError } from "../components/AlertError"
const url = "https://localhost:7211/api/usuario/register"


export function RegisterPage(){

    const [nombreCompleto, setNombreCompleto] = useState("")
    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const [isVisibleErrors, setVisibleErrors] = useState(false)
    const [errorsList, setErrorsList] = useState([]);
    const navigate = useNavigate()

    const handleOnChangeNombre = (e)=> setNombreCompleto(e.target.value)
    const handleOnChangeEmail = (e)=> setEmail(e.target.value)
    const handleOnChangePassword = (e)=> setPassword(e.target.value)

    const handleOnSubmit = async (e) =>{
        e.preventDefault();

        try{

            setErrorsList([])
            setVisibleErrors(false)

            const response =await fetch(url,{

                method: "POST",
                headers:{
                    "Content-Type": "application/json"
                },
                body:JSON.stringify({
                    nombreCompleto: nombreCompleto,
                    email: email,
                    password: password
                })


            })

            const data = await response.json()

            if(response.ok) {

                if(data.success){
                    alert(data.message)
                    navigate("/login")  
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
        catch(error){

            setErrorsList([error.message])
            setVisibleErrors(true)
        }


        
        


    }

    


    return(

        <div className="h-screen flex justify-center items-center">
            <div className="bg-slate-800 p-8 rounded-xl shadow-2xl w-full max-w-md border border-slate-700">
                
                <h1 className=" text-center mb-8 text-2xl font-bold text-white">Crear Cuenta</h1>

                
                <form onSubmit={handleOnSubmit}>
                    {/* Campo Nombre */}
                    <div className="mb-4">
                        <label className="block text-sm font-medium text-slate-400 mb-2">Nombre de Usuario</label>
                        <div className="relative">
                            <span className="absolute inset-y-0 left-0 pl-3 flex items-center text-slate-500"><i className='bx bxs-user'></i></span>
                            <input type="text" onChange={handleOnChangeNombre} className="w-full bg-slate-900 border border-slate-700 rounded-lg pl-10 pr-4 py-3 text-white focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 transition-colors" placeholder="Ej: Juan12"/>
                        </div>
                    </div>

                    {/* Campo Email */}
                    <div className="mb-4">
                        <label className="block text-sm font-medium text-slate-400 mb-2">Correo Electrónico</label>
                        <div className="relative">
                            <span className="absolute inset-y-0 left-0 pl-3 flex items-center text-slate-500"><i className='bx bxs-envelope'></i></span>
                            <input type="email" onChange={handleOnChangeEmail} className="w-full bg-slate-900 border border-slate-700 rounded-lg pl-10 pr-4 py-3 text-white focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 transition-colors" placeholder="juan@mailflow.com"/>
                        </div>
                    </div>

                    {/* Campo Contraseña */}
                    <div className="mb-6">
                        <label className="block text-sm font-medium text-slate-400 mb-2">Contraseña</label>
                        <div className="relative">
                            <span className="absolute inset-y-0 left-0 pl-3 flex items-center text-slate-500"><i className='bx bxs-lock-alt'></i></span>
                            <input type="password" onChange={handleOnChangePassword} className="w-full bg-slate-900 border border-slate-700 rounded-lg pl-10 pr-4 py-3 text-white focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 transition-colors" placeholder="••••••••"/>
                        </div>
                    </div>

                    {isVisibleErrors && <AlertError errors={errorsList}/>}
                    
                    <button type="submit" className="w-full bg-indigo-600 hover:bg-indigo-500 text-white font-bold py-3 rounded-lg transition-all shadow-lg shadow-indigo-500/20">
                        Registrarse
                    </button>
                </form>

                <div className="mt-6 text-center">
                    <p className="text-slate-400 text-sm">
                        ¿Ya tienes una cuenta?{' '}
                        <NavLink to="/login" className="text-indigo-400 hover:text-indigo-300 font-medium transition-colors">
                            Iniciar Sesión
                        </NavLink>
                    </p>
                </div>
            </div>
        </div>
    )
}