export const HeadLineStat = ({name, value, children}) => {
    return (
        <div className="w-36 mx-4">
            <div className="flex justify-between items-center font-bold">
                <h1 className="text-2xl font-bold text-white">{name}</h1>
                <div className="text-xl bg-yellow-300 p-1 rounded-md">
                    {value}
                </div>
            </div>
            {children}
        </div>
    )
}