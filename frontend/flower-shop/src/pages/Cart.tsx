import { useEffect } from "react";
import api from "../services/api";
import { useCartStore } from "../store/cartStore";

export default function Cart() {
  const { items, setCart } = useCartStore();

  useEffect(() => {
    api.get("/cart").then((res) => setCart(res.data.items));
  }, []);

  const total = items.reduce(
    (sum, i) => sum + (i.price || 0) * i.quantity,
    0
  );

  return (
    <div className="bg-white p-4 rounded shadow">
      <h2 className="text-xl mb-4">Cart</h2>

      {items.map((i) => (
        <div key={i.productId} className="flex justify-between mb-2">
          <span>{i.name}</span>
          <span>x{i.quantity}</span>
        </div>
      ))}

      <hr className="my-3" />
      <p className="font-bold">Total: ₱{total}</p>
    </div>
  );
}