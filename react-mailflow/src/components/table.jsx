import {
  useReactTable,
  getCoreRowModel,
  getPaginationRowModel,
  getSortedRowModel,
  getFilteredRowModel,
  flexRender,
} from "@tanstack/react-table";
import { useState } from "react";

export function Table({ data, columns }) {
  const [sorting, setSorting] = useState([]);
  const [globalFilter, setGlobalFilter] = useState("");
  const [inputValue, setInputValue] = useState("");
  const [pagination, setPagination] = useState({
    pageIndex: 0,
    pageSize: 10,
  });

  const table = useReactTable({
    data,
    columns,
    state: {
      sorting,
      globalFilter,
      pagination,
    },
    globalFilterFn: "includesString",
    onSortingChange: setSorting,
    onGlobalFilterChange: setGlobalFilter,
    getCoreRowModel: getCoreRowModel(),
    onPaginationChange: setPagination,
    getPaginationRowModel: getPaginationRowModel(),
    getSortedRowModel: getSortedRowModel(),
    getFilteredRowModel: getFilteredRowModel(),
  });

  const refreshOnClick = () => {
    setGlobalFilter("");
    setInputValue("");
    setSorting([]);
    setPagination({
      pageIndex: 0,
      pageSize: 10,
    });
  };

  return (
    <div className="bg-slate-800 rounded-xl border border-slate-700 shadow-lg overflow-hidden">
      <div className="p-4 border-b border-slate-700 bg-slate-800/50 flex gap-3">
        <div className="relative flex-1 max-w-md">
          <i className="bx bx-search absolute left-3 top-1/2 -translate-y-1/2 text-slate-500"></i>
          <input
            type="text"
            onChange={(e) => setInputValue(e.target.value)}
            placeholder="Buscar por nombre o email..."
            className="w-full bg-slate-900 border border-slate-600 rounded-lg py-2 pl-10 pr-4 text-slate-200 placeholder-slate-500 focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 text-sm"
          />
        </div>
        <button
          onClick={() => setGlobalFilter(inputValue)}
          className="px-3 py-2 border border-slate-600 rounded-lg text-slate-400 hover:text-white hover:bg-slate-700"
        >
          <i className="bx bx-filter-alt"></i>
        </button>

        <button
          onClick={refreshOnClick}
          className="px-3 py-2 border border-slate-600 rounded-lg text-slate-400 hover:text-white hover:bg-slate-700"
        >
          <i className="bx bx-refresh"></i>
        </button>
      </div>

      <div className="overflow-x-auto overflow-y-auto max-h-90">
        <table className="w-full text-left text-sm">
          <thead className="bg-slate-900 text-slate-400 font-medium border-b border-slate-700 uppercase text-xs tracking-wider">
            {table.getHeaderGroups().map((headerGroup) => {
              return (
                <tr className="p-4" key={headerGroup.id}>
                  <th className="p-4 w-10">
                    <input
                      type="checkbox"
                      className="rounded bg-slate-800 border-slate-600 text-indigo-500 focus:ring-0 focus:ring-offset-0"
                    />
                  </th>
                  {headerGroup.headers.map((header) => {
                    return (
                      <th
                        key={header.id}
                        className="p-4  select-none"
                        onClick={header.column.getToggleSortingHandler()}
                      >
                        <span>
                          {flexRender(
                            header.column.columnDef.header,
                            header.getContext()
                          )}
                        </span>
                        <span className="ml-1 text-xs opacity-60">
                          {{
                            asc: "▲",
                            desc: "▼",
                          }[header.column.getIsSorted()] ?? ""}
                        </span>
                      </th>
                    );
                  })}

                  <th className="p-4 text-right">Acciones</th>
                </tr>
              );
            })}
          </thead>
          <tbody className="divide-y divide-slate-700 text-slate-300">
            {table.getRowModel().rows.map((row) => {
              return (
                <tr
                  key={row.id}
                  className="hover:bg-slate-700/40 transition-colors group"
                >
                  <td className="p-4">
                    <input
                      type="checkbox"
                      className="rounded bg-slate-800 border-slate-600 text-indigo-500 focus:ring-0 focus:ring-offset-0"
                    />
                  </td>

                  {row.getVisibleCells().map((cell) => {
                    return (
                      <td key={cell.id} className="p-4 text-slate-300">
                        {flexRender(
                          cell.column.columnDef.cell ?? "sin definir",
                          cell.getContext()
                        )}
                      </td>
                    );
                  })}

                  <td className="p-4 text-right">
                    <button className="text-slate-500 hover:text-indigo-400 p-1 rounded hover:bg-slate-700 transition-colors">
                      <i className="bx bxs-pencil text-lg"></i>
                    </button>
                    <button className="text-slate-500 hover:text-red-400 p-1 rounded hover:bg-slate-700 transition-colors">
                      <i className="bx bxs-trash text-lg"></i>
                    </button>
                  </td>
                </tr>
              );
            })}

            {/* <tr className="hover:bg-slate-700/40 transition-colors group">
              <td className="p-4">
                <input
                  type="checkbox"
                  className="rounded bg-slate-800 border-slate-600 text-indigo-500 focus:ring-0 focus:ring-offset-0"
                />
              </td>
              <td className="p-4">
                <div className="flex items-center gap-3">
                  <div className="h-8 w-8 rounded-full bg-pink-600 flex items-center justify-center text-white font-bold text-xs">
                    AG
                  </div>
                  <div>
                    <div className="font-bold text-white">Ana Gómez</div>
                    <div className="text-xs text-slate-400">
                      ana.g@ejemplo.com
                    </div>
                  </div>
                </div>
              </td>
              <td className="p-4">
                <span className="px-2 py-1 bg-red-500/10 text-red-400 border border-red-500/20 rounded-md text-xs font-semibold">
                  Rebotado
                </span>
              </td>
              <td className="p-4">
                <span className="px-2 py-0.5 bg-slate-700 border border-slate-600 rounded text-xs text-slate-300">
                  Lead
                </span>
              </td>
              <td className="p-4 text-slate-400">10 Oct 2025</td>
              <td className="p-4 text-right">
                <button className="text-slate-500 hover:text-indigo-400 p-1 rounded hover:bg-slate-700 transition-colors">
                  <i className="bx bxs-pencil text-lg"></i>
                </button>
                <button className="text-slate-500 hover:text-red-400 p-1 rounded hover:bg-slate-700 transition-colors">
                  <i className="bx bxs-trash text-lg"></i>
                </button>
              </td>
            </tr> */}
          </tbody>
        </table>
      </div>

      <div className="p-4 border-t border-slate-700 bg-slate-800 flex justify-between items-center text-xs text-slate-400">
        <span>
          Página {table.getState().pagination.pageIndex + 1} de{" "}
          {table.getPageCount()}
        </span>
        <div className="flex gap-1">
          <button
            onClick={() => table.previousPage()} // Pasar a la pagina anterior
            disabled={!table.getCanPreviousPage()} // Hay una pagina previa ? (true o false)
            className="px-3 py-1 bg-slate-700 rounded hover:bg-slate-600 text-white"
          >
            Anterior
          </button>
          <button
            onClick={() => table.nextPage()} // Pasar a la pagina siguiente
            disabled={!table.getCanNextPage()} // Hay una pagina siguiente ? (true o false)
            className="px-3 py-1 bg-slate-700 rounded hover:bg-slate-600 text-white"
          >
            Siguiente
          </button>
        </div>
      </div>
    </div>
  );
}
