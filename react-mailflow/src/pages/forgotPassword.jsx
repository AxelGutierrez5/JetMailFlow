import { NavLink } from "react-router-dom"

export function ForgotPasswordPage(){

    return (
        <div className="h-screen flex justify-center items-center">
            <div className="bg-slate-800 p-8 rounded-xl shadow-2xl w-full max-w-md border border-slate-700">
                <div className="text-center mb-8">
                    <div className="inline-flex items-center justify-center w-12 h-12 rounded-lg bg-indigo-500/10 text-indigo-500 mb-4 border border-indigo-500/20">
                        {/* Icono de llave o reset */}
                        <i className='bx bxs-key text-2xl'></i>
                    </div>
                    <h1 className="text-2xl font-bold text-white">¿Olvidaste tu contraseña?</h1>
                    <p className="text-slate-400 mt-2 text-sm px-4">
                        No te preocupes. Ingresa tu correo y te enviaremos instrucciones para recuperarla.
                    </p>
                </div>
                
                <form>
                    <div className="mb-6">
                        <label className="block text-sm font-medium text-slate-400 mb-2">Correo Electrónico</label>
                        <div className="relative">
                            <span className="absolute inset-y-0 left-0 pl-3 flex items-center text-slate-500"><i className='bx bxs-envelope'></i></span>
                            <input type="email" className="w-full bg-slate-900 border border-slate-700 rounded-lg pl-10 pr-4 py-3 text-white focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 transition-colors" placeholder="admin@mailflow.com"/>
                        </div>
                    </div>
                    
                    <button type="submit" className="w-full bg-indigo-600 hover:bg-indigo-500 text-white font-bold py-3 rounded-lg transition-all shadow-lg shadow-indigo-500/20">
                        Enviar Instrucciones
                    </button>
                </form>

                <div className="mt-6 text-center">
                    <NavLink to="/login" className="text-indigo-400 hover:text-indigo-300 text-sm flex items-center justify-center gap-2 transition-colors">
                        <i className='bx bx-arrow-back'></i> Volver al inicio de sesión
                    </NavLink>
                </div>
            </div>
        </div>

    )
}