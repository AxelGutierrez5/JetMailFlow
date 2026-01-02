

export function ContactsPage()
{

    return(
    <div class="space-y-6 animate-fade-in">
        <div class="flex flex-col md:flex-row justify-between items-center gap-4">
            <h2 class="text-2xl font-bold text-white">Contactos</h2>
            <div class="flex gap-3">
                <button class="px-4 py-2 bg-slate-800 border border-slate-600 text-slate-300 rounded-lg hover:bg-slate-700 hover:text-white transition-colors text-sm flex items-center gap-2">
                    <i class='bx bxs-file-import'></i> Importar CSV
                </button>
                <button id="btn-add-contact" class="px-4 py-2 bg-indigo-600 text-white rounded-lg hover:bg-indigo-500 shadow-lg shadow-indigo-500/30 transition-all text-sm flex items-center gap-2">
                    <i class='bx bx-plus'></i> Agregar Contacto
                </button>
            </div>
        </div>

        <div class="bg-slate-800 rounded-xl border border-slate-700 shadow-lg overflow-hidden">
            <div class="p-4 border-b border-slate-700 bg-slate-800/50 flex gap-3">
                <div class="relative flex-1 max-w-md">
                    <i class='bx bx-search absolute left-3 top-1/2 -translate-y-1/2 text-slate-500'></i>
                    <input type="text" placeholder="Buscar por nombre o email..." 
                        class="w-full bg-slate-900 border border-slate-600 rounded-lg py-2 pl-10 pr-4 text-slate-200 placeholder-slate-500 focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 text-sm"/>
                </div>
                <button class="px-3 py-2 border border-slate-600 rounded-lg text-slate-400 hover:text-white hover:bg-slate-700">
                    <i class='bx bx-filter-alt'></i>
                </button>
            </div>

            <div class="overflow-x-auto">
                <table class="w-full text-left text-sm">
                    <thead class="bg-slate-900 text-slate-400 font-medium border-b border-slate-700 uppercase text-xs tracking-wider">
                        <tr>
                            <th class="p-4 w-10"><input type="checkbox" class="rounded bg-slate-800 border-slate-600 text-indigo-500 focus:ring-0 focus:ring-offset-0"/></th>
                            <th class="p-4">Perfil</th>
                            <th class="p-4">Estado</th>
                            <th class="p-4">Tags</th>
                            <th class="p-4">Fecha Alta</th>
                            <th class="p-4 text-right">Acciones</th>
                        </tr>
                    </thead>
                    <tbody class="divide-y divide-slate-700 text-slate-300">
                        <tr class="hover:bg-slate-700/40 transition-colors group">
                            <td class="p-4"><input type="checkbox" class="rounded bg-slate-800 border-slate-600 text-indigo-500 focus:ring-0 focus:ring-offset-0"/></td>
                            <td class="p-4">
                                <div class="flex items-center gap-3">
                                    <div class="h-8 w-8 rounded-full bg-indigo-500 flex items-center justify-center text-white font-bold text-xs">CP</div>
                                    <div>
                                        <div class="font-bold text-white">Carlos Pérez</div>
                                        <div class="text-xs text-slate-500">carlos@ejemplo.com</div>
                                    </div>
                                </div>
                            </td>
                            <td class="p-4">
                                <span class="px-2 py-1 bg-emerald-500/10 text-emerald-400 border border-emerald-500/20 rounded-md text-xs font-semibold">Suscrito</span>
                            </td>
                            <td class="p-4">
                                <div class="flex gap-1">
                                    <span class="px-2 py-0.5 bg-slate-700 border border-slate-600 rounded text-xs text-slate-300">Dev</span>
                                    <span class="px-2 py-0.5 bg-slate-700 border border-slate-600 rounded text-xs text-slate-300">VIP</span>
                                </div>
                            </td>
                            <td class="p-4 text-slate-400">12 Oct 2025</td>
                            <td class="p-4 text-right">
                                <button class="text-slate-500 hover:text-indigo-400 p-1 rounded hover:bg-slate-700 transition-colors"><i class='bx bxs-pencil text-lg'></i></button>
                                <button class="text-slate-500 hover:text-red-400 p-1 rounded hover:bg-slate-700 transition-colors"><i class='bx bxs-trash text-lg'></i></button>
                            </td>
                        </tr>
                        <tr class="hover:bg-slate-700/40 transition-colors group">
                            <td class="p-4"><input type="checkbox" class="rounded bg-slate-800 border-slate-600 text-indigo-500 focus:ring-0 focus:ring-offset-0"/></td>
                            <td class="p-4">
                                <div class="flex items-center gap-3">
                                    <div class="h-8 w-8 rounded-full bg-pink-600 flex items-center justify-center text-white font-bold text-xs">AG</div>
                                    <div>
                                        <div class="font-bold text-white">Ana Gómez</div>
                                        <div class="text-xs text-slate-500">ana.g@ejemplo.com</div>
                                    </div>
                                </div>
                            </td>
                            <td class="p-4">
                                <span class="px-2 py-1 bg-red-500/10 text-red-400 border border-red-500/20 rounded-md text-xs font-semibold">Rebotado</span>
                            </td>
                            <td class="p-4">
                                <span class="px-2 py-0.5 bg-slate-700 border border-slate-600 rounded text-xs text-slate-300">Lead</span>
                            </td>
                            <td class="p-4 text-slate-400">10 Oct 2025</td>
                            <td class="p-4 text-right">
                                <button class="text-slate-500 hover:text-indigo-400 p-1 rounded hover:bg-slate-700 transition-colors"><i class='bx bxs-pencil text-lg'></i></button>
                                <button class="text-slate-500 hover:text-red-400 p-1 rounded hover:bg-slate-700 transition-colors"><i class='bx bxs-trash text-lg'></i></button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            
            <div class="p-4 border-t border-slate-700 bg-slate-800 flex justify-between items-center text-xs text-slate-400">
                <span>Mostrando 1-10 de 240</span>
                <div class="flex gap-1">
                    <button class="px-3 py-1 bg-slate-700 rounded hover:bg-slate-600 text-white">Anterior</button>
                    <button class="px-3 py-1 bg-slate-700 rounded hover:bg-slate-600 text-white">Siguiente</button>
                </div>
            </div>
        </div>
    </div>)

       

}