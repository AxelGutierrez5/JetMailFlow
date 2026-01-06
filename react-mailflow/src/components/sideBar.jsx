import { NavLink } from "react-router-dom";

export function SideBar() {
  const base =
    "w-full flex items-center px-4 py-3 text-sm font-medium rounded-lg transition-colors group";

  const active =
    "text-indigo-400 bg-indigo-500/10";

  const inactive =
    "text-slate-400 hover:text-indigo-400 hover:bg-slate-700/50";

  return (
    <aside className="w-64 bg-slate-800 border-r border-slate-700 hidden md:flex md:flex-col shrink-0 transition-all duration-300">
      
      {/* Logo */}
      <div className="h-16 flex items-center px-6 border-b border-slate-700">
        <i className="bx bx-paper-plane text-indigo-500 text-2xl mr-2"></i>
        <span className="text-xl font-bold tracking-wide text-white">
          JetMailFlow
        </span>
      </div>

      {/* Navigation */}
      <nav className="flex-1 overflow-y-auto py-6 px-3 space-y-1">

        {/* Dashboard */}
        <NavLink
          to="/dashboard"
          end
          className={({ isActive }) =>
            `${base} ${isActive ? active : inactive}`
          }
        >
          <i className="bx bxs-dashboard text-xl mr-3"></i>
          Dashboard
        </NavLink>

        {/* Contactos */}
        <NavLink
          to="/contacts"
          className={({ isActive }) =>
            `${base} ${isActive ? active : inactive}`
          }
        >
          <i className="bx bxs-contact text-xl mr-3"></i>
          Contactos
        </NavLink>

        {/* Listas */}
        <NavLink
          to="/lists"
          className={({ isActive }) =>
            `${base} ${isActive ? active : inactive}`
          }
        >
          <i className="bx bx-list-ul text-xl mr-3"></i>
          Listas
        </NavLink>

        {/* Campañas */}
        <NavLink
          to="/campaigns"
          className={({ isActive }) =>
            `${base} ${isActive ? active : inactive}`
          }
        >
          <i className="bx bxs-megaphone text-xl mr-3"></i>
          Campañas
        </NavLink>

        {/* Editor */}
        <NavLink
          to="/editor"
          className={({ isActive }) =>
            `${base} ${isActive ? active : inactive}`
          }
        >
          <i className="bx bxs-edit text-xl mr-3"></i>
          Editor Email
        </NavLink>

        {/* Sistema */}
        <div className="pt-6 pb-2 px-4 text-xs font-semibold text-slate-500 uppercase tracking-wider">
          Sistema
        </div>

        {/* Configuración */}
        <NavLink
          to="/settings"
          className={({ isActive }) =>
            `${base} ${isActive ? active : inactive}`
          }
        >
          <i className="bx bxs-cog text-xl mr-3"></i>
          Configuración
        </NavLink>
      </nav>

      {/* Logout */}
      <div className="p-4 border-t border-slate-700">
        <button className="w-full flex items-center px-4 py-2 text-sm font-medium text-red-400 hover:bg-red-500/10 rounded-lg transition-colors">
          <i className="bx bx-log-out text-xl mr-3"></i>
          Cerrar Sesión
        </button>
      </div>
    </aside>
  );
}
