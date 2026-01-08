

export function AlertError({errors}){

    return (<div className="mb-6 w-full bg-red-500/10 border border-red-500/30 text-red-400 px-4 py-3 rounded-lg text-sm text-left">
                <ul className="list-none ls pl-4 space-y-1">
                    {errors.map(error=>  <li>{error}</li>)}
                </ul> 
            </div>)

}