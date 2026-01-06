
export function InputPersonalize({type="text",value="", placeHolder="", onChange=()=> "", iconClass=""})
{

    const baseIcon = `${iconClass} absolute left-3 top-1/2 -translate-y-1/2 text-slate-500 group-focus-within:text-indigo-500 transition-colors`

    if(iconClass){

        return (<div className="relative">
                    <i className={baseIcon} ></i>
                    <input 
                        className="w-full bg-slate-900 border border-slate-600 rounded-lg py-2.5 pl-10 pr-4 text-white placeholder-slate-500 focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 text-sm transition-all"
                        type={type} 
                        placeholder={placeHolder} 
                        onChange={onChange} 
                        value={value} required/>

                </div>)
    }
    else return <input 
                className="w-full bg-slate-900 border border-slate-600 rounded-lg py-2.5 pl-10 pr-4 text-white placeholder-slate-500 focus:outline-none focus:border-indigo-500 focus:ring-1 focus:ring-indigo-500 text-sm transition-all"
                type={type} 
                placeholder={placeHolder} 
                onChange={onChange} 
                value={value}  required/>

   

    
    
                       
    
    
    
}