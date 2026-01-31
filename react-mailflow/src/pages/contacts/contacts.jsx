import { ModalContact } from "./modalContact";
import { useEffect, useState } from "react";
import { Table } from "../../components/Table";

const url = "https://localhost:7211/api/contacto/listcontactos";

export function ContactsPage() {
  const [isOpenModal, setModal] = useState(false);
  const [dataContacts, setData] = useState([]);

  const openModal = () => setModal(true);
  const closeModal = () => setModal(false);

  const getContacts = async () => {
    try {
      const response = await fetch(url);
      const data = await response.json();
      if (response.ok) {
        setData(data.value);
      } else {
        alert(data.message);
      }
    } catch (error) {
      alert("Error inespeado");
    }
  };

  const columns = [
    {
      header: "ID",
      accessorKey: "contactoId",
    },
    {
      id: "nombreCompleto",
      header: "Nombre Completo",
      accessorFn: (row) => row.nombre + ", " + row.apellido,
      enableGlobalFilter: true,
    },
    {
      header: "Email",
      accessorKey: "email",
    },
    {
      header: "Creacion",
      accessorKey: "creacion",
    },
    {
      header: "Estado",
      accessorKey: "estado",
      cell: (info) => (
        <span
          className={
            info.getValue() === "Activo"
              ? "px-2 py-1 bg-emerald-500/10 text-emerald-400 border border-emerald-500/20 rounded-md text-xs font-semibold"
              : "px-2 py-1 bg-red-500/10 text-red-400 border border-red-500/20 rounded-md text-xs font-semibold"
          }
        >
          {info.getValue()}
        </span>
      ),
    },
  ];

  useEffect(() => {
    const fetchContacts = async () => {
      await getContacts();
    };

    fetchContacts();
  }, []);

  return (
    <>
      <div className="space-y-6 animate-fade-in">
        <div className="flex justify-between items-center ">
          <h2 className="text-2xl font-bold text-white">Contactos</h2>
          <div className="flex gap-3">
            <button className="px-4 py-2 bg-slate-800 border border-slate-600 text-slate-300 rounded-lg hover:bg-slate-700 hover:text-white transition-colors text-sm flex items-center gap-2">
              <i className="bx bxs-file-import"></i> Importar CSV
            </button>
            <button
              onClick={openModal}
              className="px-4 py-2 bg-indigo-600 text-white rounded-lg hover:bg-indigo-500 shadow-lg shadow-indigo-500/30 transition-all text-sm flex items-center gap-2"
            >
              <i className="bx bx-plus"></i> Agregar Contacto
            </button>
          </div>
        </div>

        <Table data={dataContacts} columns={columns} />
      </div>

      {isOpenModal && (
        <ModalContact
          titleName="Crear Nuevo Contacto"
          closeModal={closeModal}
        />
      )}
    </>
  );
}
