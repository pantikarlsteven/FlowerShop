import { useState } from "react";
import api from "../services/api";

export default function Checkout() {
  const [address, setAddress] = useState("");

  const checkout = async () => {
    const res = await api.post("/checkout", { address });
    alert("Order ID: " + res.data.orderId);
  };

  return (
    <div>
      <h2>Checkout</h2>
      <input placeholder="Address" onChange={(e) => setAddress(e.target.value)} />
      <button onClick={checkout}>Place Order</button>
    </div>
  );
}