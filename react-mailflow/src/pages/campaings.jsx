

export function CampaniaPage(){


    return (
    <div className="space-y-6 animate-fade-in">
        <div className="flex justify-between items-center">
            <h2 className="text-2xl font-bold text-white">Campañas</h2>
            
            <button className="px-4 py-2 bg-indigo-600 text-white rounded-lg hover:bg-indigo-500 shadow-lg shadow-indigo-500/30 transition-all text-sm font-medium">
                <i className='bx bx-plus mr-1'></i> Crear Campaña
            </button>
        </div>

        <div className="space-y-4">
            
            <div className="bg-slate-800 rounded-xl p-5 border border-slate-700 hover:border-slate-600 transition-all shadow-md group">
                <div className="flex flex-col md:flex-row justify-between md:items-center gap-4">
                    <div className="flex-1">
                        <div className="flex items-center gap-3 mb-1">
                            <h3 className="text-lg font-bold text-white group-hover:text-indigo-400 transition-colors">Lanzamiento Producto v2</h3>
                            <span className="px-2 py-0.5 bg-emerald-500/10 text-emerald-400 border border-emerald-500/20 rounded text-xs font-semibold">Enviado</span>
                        </div>
                        <p className="text-slate-400 text-sm">Lista: <span className="text-slate-300">Clientes VIP</span> • 15 Ene, 10:00 AM</p>
                    </div>
                    
                    <div className="flex items-center gap-6 md:border-l md:border-slate-700 md:pl-6">
                        <div className="text-center">
                            <div className="text-xl font-bold text-white">45%</div>
                            <div className="text-xs text-slate-500 uppercase">Aperturas</div>
                        </div>
                        <div className="text-center">
                            <div className="text-xl font-bold text-white">12%</div>
                            <div className="text-xs text-slate-500 uppercase">Clics</div>
                        </div>
                        <div className="flex gap-2">
                            <button className="p-2 text-slate-400 hover:text-white bg-slate-900 rounded-lg hover:bg-slate-700 transition-colors" title="Reporte"><i className='bx bxs-bar-chart-alt-2'></i></button>
                            <button className="p-2 text-slate-400 hover:text-white bg-slate-900 rounded-lg hover:bg-slate-700 transition-colors" title="Duplicar"><i className='bx bx-copy'></i></button>
                        </div>
                    </div>
                </div>
            </div>

            <div className="bg-slate-800 rounded-xl p-5 border border-slate-700 hover:border-slate-600 transition-all shadow-md group">
                <div className="flex flex-col md:flex-row justify-between md:items-center gap-4">
                    <div className="flex-1">
                        <div className="flex items-center gap-3 mb-1">
                            <h3 className="text-lg font-bold text-white group-hover:text-indigo-400 transition-colors">Newsletter Semanal #42</h3>
                            <span className="px-2 py-0.5 bg-yellow-500/10 text-yellow-400 border border-yellow-500/20 rounded text-xs font-semibold">Programado</span>
                        </div>
                        <p className="text-slate-400 text-sm">Lista: <span className="text-slate-300">Newsletter General</span> • Mañana, 09:00 AM</p>
                    </div>
                    
                    <div className="flex items-center gap-4 md:border-l md:border-slate-700 md:pl-6 w-full md:w-auto">
                    <div className="w-full md:w-32">
                        <div className="flex justify-between text-xs text-slate-400 mb-1">
                            <span>Cuenta atrás</span>
                            <span>14h</span>
                        </div>
                        <div className="w-full bg-slate-900 h-1.5 rounded-full overflow-hidden">
                            <div className="bg-yellow-500 h-1.5 rounded-full w-[70%]" ></div>
                        </div>
                    </div>
                    <div className="flex gap-2">
                            <button className="p-2 text-slate-400 hover:text-white bg-slate-900 rounded-lg hover:bg-slate-700 transition-colors"><i className='bx bxs-pencil'></i></button>
                            <button className="p-2 text-slate-400 hover:text-red-400 bg-slate-900 rounded-lg hover:bg-slate-700 transition-colors"><i className='bx bx-stop-circle'></i></button>
                        </div>
                    </div>
                </div>
            </div>

            <div className="bg-slate-800 rounded-xl p-5 border border-slate-700 border-dashed hover:border-slate-500 transition-all shadow-sm opacity-80 hover:opacity-100">
                <div className="flex flex-col md:flex-row justify-between md:items-center gap-4">
                    <div className="flex-1">
                        <div className="flex items-center gap-3 mb-1">
                            <h3 className="text-lg font-bold text-slate-300">Oferta Black Friday</h3>
                            <span className="px-2 py-0.5 bg-slate-700 text-slate-400 border border-slate-600 rounded text-xs font-semibold">Borrador</span>
                        </div>
                        <p className="text-slate-500 text-sm">Editado hace 3 días</p>
                    </div>
                    <div className="flex gap-2">
                        <button className="px-4 py-2 bg-slate-700 text-white text-sm rounded-lg hover:bg-slate-600 transition-colors">Continuar Editando</button>
                    </div>
                </div>
            </div>

        </div>
    </div>)

}