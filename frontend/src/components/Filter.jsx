export const Filter = ({ filterText, onFilter, onClear, placeholder, className }) => (
    <div className={`${className} border-b-fc24-400 border-2  my-2 px-2 py-1`}>
        <input
            className="text-white bg-fc24-black"
            id="search"
            type="text"
            placeholder={placeholder}
            aria-label="Search Input"
            value={filterText}
            onChange={onFilter}
        />
        <button type="button" className="text-fc24-accent px-2" onClick={onClear}>
            X
        </button>
    </div>
);
