
export function Header({title,nameUser})
{

    return ( 
    <header className="h-16 bg-slate-800 border-b border-slate-700 flex items-center justify-between px-6 shadow-md z-10 shrink-0">

                <div className="flex items-center md:hidden">
                    <button className="text-slate-400 hover:text-white"><i className='bx bx-menu text-2xl'></i></button>
                    <span className="ml-3 font-bold text-white text-lg">MAILFLOW</span>
                </div>
                
                <h2 id="page-title" className="hidden md:block text-lg font-semibold text-slate-200">{title}</h2>
                
                <div className="flex items-center space-x-4">
                    <button className="relative p-2 text-slate-400 hover:text-indigo-400 transition-colors">
                        <i className='bx bxs-bell text-xl'></i>
                        <span className="absolute top-1.5 right-1.5 h-2 w-2 rounded-full bg-red-500 border border-slate-800"></span>
                    </button>
                    <div className="flex items-center space-x-3 border-l border-slate-700 pl-4">
                        <div className="h-8 w-8 rounded-full bg-indigo-500/20 text-indigo-400 flex items-center justify-center font-bold text-xs border border-indigo-500/30">JS</div>
                        <span className="text-sm font-medium text-slate-300 hidden sm:block">{nameUser}</span>
                    </div>
                </div>
            </header>)   
}