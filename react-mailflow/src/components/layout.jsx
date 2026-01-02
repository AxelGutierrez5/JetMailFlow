import { SideBar } from "./sideBar"
import { Header } from "./header"
import { Outlet } from "react-router-dom";


export function Layout(){

   

    return(
    <div className="flex h-screen w-full">
        
        <SideBar></SideBar>

        <div className="flex-1 flex flex-col h-screen overflow-hidden bg-slate-900">
            
            <Header title="Titulo" nameUser="Default" ></Header>
            <main className="flex-1 overflow-x-hidden overflow-y-auto p-6 relative">
                <Outlet />
            </main>

        </div>
    </div>)



}

