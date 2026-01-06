
export function Settings(){

    return(
        <div className="max-w-3xl mx-auto animate-fade-in">
    <h2 className="text-2xl font-bold text-white mb-6">Configuración del Sistema</h2>
    
    <div className="bg-slate-800 rounded-xl border border-slate-700 shadow-lg p-6 mb-6">
        <h3 className="text-lg font-semibold text-white mb-4 flex items-center">
            <i className='bx bxs-server text-indigo-500 mr-2'></i> Configuración SMTP
        </h3>
        <p className="text-slate-400 text-sm mb-6 border-b border-slate-700 pb-4">Define el servidor de correo saliente para tus campañas.</p>

        <form className="space-y-6">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                <div>
                    <label className="block text-sm font-medium text-slate-400 mb-2">Host SMTP</label>
                    <input type="text" value="smtp.gmail.com" 
                           className="w-full bg-slate-900 border border-slate-600 rounded-lg px-4 py-2.5 text-white focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 transition-colors"/>
                </div>
                <div>
                    <label className="block text-sm font-medium text-slate-400 mb-2">Puerto</label>
                    <input type="text" value="587" 
                           className="w-full bg-slate-900 border border-slate-600 rounded-lg px-4 py-2.5 text-white focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 transition-colors"/>
                </div>
            </div>

            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                <div>
                    <label className="block text-sm font-medium text-slate-400 mb-2">Usuario SMTP</label>
                    <input type="text" placeholder="user@domain.com" 
                           className="w-full bg-slate-900 border border-slate-600 rounded-lg px-4 py-2.5 text-white focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 transition-colors"/>
                </div>
                <div>
                    <label className="block text-sm font-medium text-slate-400 mb-2">Método Encriptación</label>
                    <div className="relative">
                        <select className="w-full bg-slate-900 border border-slate-600 rounded-lg px-4 py-2.5 text-white appearance-none focus:outline-none focus:border-indigo-500 cursor-pointer">
                            <option>TLS (Recomendado)</option>
                            <option>SSL</option>
                            <option>Ninguno</option>
                        </select>
                        <i className='bx bx-chevron-down absolute right-4 top-1/2 -translate-y-1/2 text-slate-400 pointer-events-none'></i>
                    </div>
                </div>
            </div>

            <div>
                <label className="block text-sm font-medium text-slate-400 mb-2">Contraseña / App Password</label>
                <input type="password" value="••••••••••••" 
                       className="w-full bg-slate-900 border border-slate-600 rounded-lg px-4 py-2.5 text-white focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 transition-colors"/>
            </div>
        </form>
    </div>

    <div className="bg-slate-800 rounded-xl border border-slate-700 shadow-lg p-6">
        <h3 className="text-lg font-semibold text-white mb-4 flex items-center">
            <i className='bx bxs-tachometer text-emerald-500 mr-2'></i> Límites de Envío
        </h3>
        <div className="flex items-center justify-between bg-slate-900 p-4 rounded-lg border border-slate-700">
            <div>
                <p className="text-white font-medium">Límite Diario</p>
                <p className="text-xs text-slate-400">Pausa los envíos al alcanzar este número.</p>
            </div>
            <div className="flex items-center gap-2">
                <input type="number" value="2000" className="w-24 bg-slate-800 border border-slate-600 rounded-lg px-3 py-1 text-white text-right focus:border-indigo-500 outline-none"/>
                <span className="text-slate-500 text-sm">emails</span>
            </div>
        </div>
        
        <div className="mt-6 flex justify-end">
            <button className="px-6 py-3 bg-indigo-600 hover:bg-indigo-500 text-white font-bold rounded-lg shadow-lg shadow-indigo-500/20 transition-all">
                Guardar Cambios
            </button>
        </div>
    </div>
</div>)
}