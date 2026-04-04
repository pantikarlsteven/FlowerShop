import { useEffect, useState } from "react";
import api from "../../services/api";

export default function AdminProducts() {
  const [products, setProducts] = useState<any[]>([]);
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");

  const load = () => {
    api.get("/products").then((res) => setProducts(res.data));
  };

  useEffect(load, []);

  const create = async () => {
    await api.post("/products", {
      name,
      price: Number(price),
      description: "",
      stock: 10,
    });
    load();
  };

  return (
    <div>
      <h2 className="text-xl mb-4">Admin Products</h2>

      <div className="mb-4 flex gap-2">
        <input
          placeholder="Name"
          onChange={(e) => setName(e.target.value)}
          className="border p-2"
        />
        <input
          placeholder="Price"
          onChange={(e) => setPrice(e.target.value)}
          className="border p-2"
        />
        <button onClick={create} className="bg-blue-500 text-white px-3">
          Add
        </button>
      </div>

      {products.map((p) => (
        <div key={p.id} className="flex justify-between border-b py-2">
          <span>{p.name}</span>
          <span>₱{p.price}</span>
        </div>
      ))}
    </div>
  );
}