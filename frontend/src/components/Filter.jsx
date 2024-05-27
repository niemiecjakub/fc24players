export const Filter = ({ filterText, onFilter, onClear, placeholder, className }) => (
    <div className={className}>
        <input
            className="bg-amber-300"
            id="search"
            type="text"
            placeholder={placeholder}
            aria-label="Search Input"
            value={filterText}
            onChange={onFilter}
        />
        <button type="button" onClick={onClear}>
            X
        </button>
    </div>
);
