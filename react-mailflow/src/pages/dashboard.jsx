
export function DashboardPage()
{

    return (
        
    <div className="space-y-6 animate-fade-in">
       
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
            
            <div className="bg-slate-800 rounded-xl p-6 border border-slate-700 shadow-lg flex justify-between items-start hover:border-indigo-500/50 transition-colors">
                <div>
                    <p className="text-slate-400 text-xs font-semibold uppercase tracking-wider">Emails Enviados</p>
                    <h3 className="text-3xl font-bold text-white mt-2">24,593</h3>
                    <div className="mt-2 flex items-center text-xs font-medium text-emerald-400 bg-emerald-400/10 px-2 py-1 rounded w-fit">
                        <i className='bx bx-trending-up mr-1'></i> +12%
                    </div>
                </div>
                <div className="p-3 bg-indigo-500/10 rounded-lg text-indigo-400">
                    <i className='bx bxs-paper-plane text-2xl'></i>
                </div>
            </div>

            <div className="bg-slate-800 rounded-xl p-6 border border-slate-700 shadow-lg flex justify-between items-start hover:border-emerald-500/50 transition-colors">
                <div>
                    <p className="text-slate-400 text-xs font-semibold uppercase tracking-wider">Tasa de Apertura</p>
                    <h3 className="text-3xl font-bold text-white mt-2">42.8%</h3>
                    <div className="mt-2 flex items-center text-xs font-medium text-emerald-400 bg-emerald-400/10 px-2 py-1 rounded w-fit">
                        <i className='bx bx-trending-up mr-1'></i> +3.2%
                    </div>
                </div>
                <div className="p-3 bg-emerald-500/10 rounded-lg text-emerald-400">
                    <i className='bx bx-envelope-open text-2xl'></i>
                </div>
            </div>

            <div className="bg-slate-800 rounded-xl p-6 border border-slate-700 shadow-lg flex justify-between items-start hover:border-blue-500/50 transition-colors">
                <div>
                    <p className="text-slate-400 text-xs font-semibold uppercase tracking-wider">Tasa de Clics</p>
                    <h3 className="text-3xl font-bold text-white mt-2">15.4%</h3>
                    <div className="mt-2 flex items-center text-xs font-medium text-red-400 bg-red-400/10 px-2 py-1 rounded w-fit">
                        <i className='bx bx-trending-down mr-1'></i> -1.1%
                    </div>
                </div>
                <div className="p-3 bg-blue-500/10 rounded-lg text-blue-400">
                    <i className='bx bxs-mouse-alt text-2xl'></i>
                </div>
            </div>

            <div className="bg-slate-800 rounded-xl p-6 border border-slate-700 shadow-lg flex justify-between items-start hover:border-red-500/50 transition-colors">
                <div>
                    <p className="text-slate-400 text-xs font-semibold uppercase tracking-wider">Rebotes</p>
                    <h3 className="text-3xl font-bold text-white mt-2">1.2%</h3>
                    <div className="mt-2 flex items-center text-xs font-medium text-slate-400 bg-slate-700/50 px-2 py-1 rounded w-fit">
                        <i className='bx bx-minus mr-1'></i> Estable
                    </div>
                </div>
                <div className="p-3 bg-red-500/10 rounded-lg text-red-400">
                    <i className='bx bxs-error-circle text-2xl'></i>
                </div>
            </div>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
            
            <div className="bg-slate-800 rounded-xl border border-slate-700 p-6 lg:col-span-2 shadow-lg">
                <div className="flex justify-between items-center mb-6">
                    <h3 className="text-lg font-bold text-white">Rendimiento de Campañas</h3>
                    <button className="text-slate-400 hover:text-white"><i className='bx bx-dots-horizontal-rounded text-xl'></i></button>
                </div>
                <div className="relative w-full h-72">
                    <canvas id="dashboardChart"></canvas>
                </div>
            </div>

            <div className="bg-slate-800 rounded-xl border border-slate-700 p-6 shadow-lg">
                <h3 className="text-lg font-bold text-white mb-6">Actividad Reciente</h3>
                <div className="space-y-5">
                    <div className="flex gap-4">
                        <div className="h-10 w-10 rounded-full bg-indigo-500/10 border border-indigo-500/20 text-indigo-400 flex items-center justify-center shrink-0">
                            <i className='bx bxs-send'></i>
                        </div>
                        <div>
                            <p className="text-sm text-white font-medium">Campaña "Verano" enviada</p>
                            <p className="text-xs text-slate-400 mt-1">Hace 2 horas • 2,400 destinatarios</p>
                        </div>
                    </div>
                    <div className="flex gap-4">
                        <div className="h-10 w-10 rounded-full bg-emerald-500/10 border border-emerald-500/20 text-emerald-400 flex items-center justify-center shrink-0">
                            <i className='bx bxs-user-plus'></i>
                        </div>
                        <div>
                            <p className="text-sm text-white font-medium">Nuevo registro: Ana García</p>
                            <p className="text-xs text-slate-400 mt-1">Hace 4 horas • Desde Landing Page</p>
                        </div>
                    </div>
                    <div className="flex gap-4">
                        <div className="h-10 w-10 rounded-full bg-orange-500/10 border border-orange-500/20 text-orange-400 flex items-center justify-center shrink-0">
                            <i className='bx bxs-error'></i>
                        </div>
                        <div>
                            <p className="text-sm text-white font-medium">Alta tasa de rebote detectada</p>
                            <p className="text-xs text-slate-400 mt-1">Ayer • Lista "Antiguos"</p>
                        </div>
                    </div>
                </div>
                <button className="w-full mt-6 py-2 text-sm text-slate-400 hover:text-indigo-400 border border-slate-700 rounded-lg hover:border-indigo-500/50 transition-all">
                    Ver todo el historial
                </button>
            </div>
        </div>
    </div>)
}