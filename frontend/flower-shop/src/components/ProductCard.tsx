export default function ProductCard({ product, onAdd }: any) {
  return (
    <div className="bg-white p-4 rounded shadow">
      <h3 className="font-bold">{product.name}</h3>
      <p className="text-gray-500">{product.description}</p>
      <p className="text-pink-600 font-semibold">₱{product.price}</p>

      <button
        onClick={() => onAdd(product.id)}
        className="mt-2 bg-pink-500 text-white px-3 py-1 rounded"
      >
        Add to Cart
      </button>
    </div>
  );
}