
export function ModalContact({titleName, closeModal}){

    const saveContact = ()=>{

    }


    return (

        <div className="fixed inset-0 z-50 flex items-center justify-center p-4 sm:p-6 animate-fade-in bg-slate-900/80 backdrop-blur-sm transition-opacity ">
      
          
            <div className="w-full max-w-lg  overflow-hidden rounded-xl bg-slate-800 border border-slate-700 shadow-2xl transition-all">
                
                {/* Header */}
                <div className="flex items-center justify-between border-b border-slate-700 p-6 bg-slate-800/50">
                    <h3 className="text-xl font-bold text-white">{titleName}</h3>
                    <button className="text-slate-400 hover:text-white transition-colors rounded-lg p-1 hover:bg-slate-700">
                        <i className='bx bx-x text-2xl' onClick={closeModal}></i>
                    </button>
                </div>

                {/* Body - Formulario */}
                <div className="p-6 space-y-5">
                
                    {/* Campo: Nombre */}
                    <div className="space-y-2">
                        <label className="block text-sm font-medium text-slate-300">Nombre Completo</label>
                        <div className="relative group">
                            <i className='bx bx-user absolute left-3 top-1/2 -translate-y-1/2 text-slate-500 group-focus-within:text-indigo-500 transition-colors'></i>
                            <input 
                                type="text" 
                                placeholder="Ej. Juan Pérez" 
                                className="w-full bg-slate-900 border border-slate-600 rounded-lg py-2.5 pl-10 pr-4 text-slate-200 placeholder-slate-500 focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 text-sm transition-all"
                            />

                        </div>
                    </div>

                    {/* Campo: Correo */}
                    <div className="space-y-2">
                        <label className="block text-sm font-medium text-slate-300">Correo Electrónico</label>
                        <div className="relative group">
                            <i className='bx bx-envelope absolute left-3 top-1/2 -translate-y-1/2 text-slate-500 group-focus-within:text-indigo-500 transition-colors'></i>
                            <input 
                                type="email" 
                                placeholder="juan@ejemplo.com" 
                                className="w-full bg-slate-900 border border-slate-600 rounded-lg py-2.5 pl-10 pr-4 text-slate-200 placeholder-slate-500 focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 text-sm transition-all"
                            />
                        </div>
                    </div>

                    {/* Grid de 2 columnas para Estado y Tags */}
                    <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
                        
                        {/* Campo: Estado */}
                        <div className="space-y-2">
                            <label className=" block text-sm font-medium text-slate-300">Estado Inicial</label>
                            <div className="relative group">
                                <i className='bx bx-check-circle absolute left-3 top-1/2 -translate-y-1/2 text-slate-500 group-focus-within:text-indigo-500 transition-colors'></i>
                                <select className="w-full bg-slate-900 border border-slate-600 rounded-lg py-2.5 pl-10 pr-8 text-slate-200 focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 text-sm appearance-none cursor-pointer">
                                <option value="subscribed">Suscrito</option>
                                <option value="pending">Pendiente</option>
                                <option value="unsubscribed">Desuscrito</option>
                                </select>
                                <i className='bx bx-chevron-down absolute right-3 top-1/2 -translate-y-1/2 text-slate-500 pointer-events-none'></i>
                            </div>
                        </div>

                        {/* Campo: Tags */}
                        <div className="space-y-2">
                            <label className="block text-sm font-medium text-slate-300">Etiqueta (Tag)</label>
                            <div className="relative group">
                                <i className='bx bx-tag absolute left-3 top-1/2 -translate-y-1/2 text-slate-500 group-focus-within:text-indigo-500 transition-colors'></i>
                                <input 
                                type="text" 
                                placeholder="Ej. VIP" 
                                className="w-full bg-slate-900 border border-slate-600 rounded-lg py-2.5 pl-10 pr-4 text-slate-200 placeholder-slate-500 focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 text-sm transition-all"
                                />
                            </div>
                        </div>
                    </div>
                </div>

                {/* Footer - Botones de Acción */}
                <div className="flex flex-col sm:flex-row justify-end gap-3 border-t border-slate-700 bg-slate-800/50 p-6">
                    <button onClick={closeModal} className="px-4 py-2 bg-transparent border border-slate-600 hover:bg-slate-700 text-slate-300 hover:text-white rounded-lg transition-colors text-sm font-medium">
                        Cancelar
                    </button>
                    <button className="px-4 py-2 bg-indigo-600 hover:bg-indigo-500 text-white rounded-lg shadow-lg shadow-indigo-500/30 transition-all text-sm font-medium flex items-center justify-center gap-2">
                        <i className='bx bx-save'></i>
                        Guardar Contacto
                    </button>
                </div>

            </div>
        </div>

    )

}