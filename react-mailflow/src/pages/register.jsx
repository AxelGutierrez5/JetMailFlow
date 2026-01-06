import { NavLink } from "react-router-dom"

export function RegisterPage(){

    document.get
    return(

        <div className="h-screen flex justify-center items-center">
            <div className="bg-slate-800 p-8 rounded-xl shadow-2xl w-full max-w-md border border-slate-700">
                <div className="text-center mb-8">
                    
                    <h1 className="text-2xl font-bold text-white">Crear Cuenta</h1>
                    <p className="text-slate-400 mt-2">Únete a JetMailFlow hoy</p>
                </div>
                
                <form>
                    {/* Campo Nombre */}
                    <div className="mb-4">
                        <label className="block text-sm font-medium text-slate-400 mb-2">Nombre de Usuario</label>
                        <div className="relative">
                            <span className="absolute inset-y-0 left-0 pl-3 flex items-center text-slate-500"><i className='bx bxs-user'></i></span>
                            <input type="text" className="w-full bg-slate-900 border border-slate-700 rounded-lg pl-10 pr-4 py-3 text-white focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 transition-colors" placeholder="Ej: Juan12"/>
                        </div>
                    </div>

                    {/* Campo Email */}
                    <div className="mb-4">
                        <label className="block text-sm font-medium text-slate-400 mb-2">Correo Electrónico</label>
                        <div className="relative">
                            <span className="absolute inset-y-0 left-0 pl-3 flex items-center text-slate-500"><i className='bx bxs-envelope'></i></span>
                            <input type="email" className="w-full bg-slate-900 border border-slate-700 rounded-lg pl-10 pr-4 py-3 text-white focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 transition-colors" placeholder="juan@mailflow.com"/>
                        </div>
                    </div>

                    {/* Campo Contraseña */}
                    <div className="mb-6">
                        <label className="block text-sm font-medium text-slate-400 mb-2">Contraseña</label>
                        <div className="relative">
                            <span className="absolute inset-y-0 left-0 pl-3 flex items-center text-slate-500"><i className='bx bxs-lock-alt'></i></span>
                            <input type="password" className="w-full bg-slate-900 border border-slate-700 rounded-lg pl-10 pr-4 py-3 text-white focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 transition-colors" placeholder="••••••••"/>
                        </div>
                    </div>
                    
                    <button type="submit" className="w-full bg-indigo-600 hover:bg-indigo-500 text-white font-bold py-3 rounded-lg transition-all shadow-lg shadow-indigo-500/20">
                        Registrarse
                    </button>
                </form>

                <div className="mt-6 text-center">
                    <p className="text-slate-400 text-sm">
                        ¿Ya tienes una cuenta?{' '}
                        <NavLink to="/login" className="text-indigo-400 hover:text-indigo-300 font-medium transition-colors">
                            Inicia Sesión
                        </NavLink>
                    </p>
                </div>
            </div>
        </div>
    )
}