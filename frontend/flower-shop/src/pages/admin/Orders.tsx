import { useEffect, useState } from "react";
import api from "../../services/api";
import toast from "react-hot-toast";

export default function AdminOrders() {
  const [orders, setOrders] = useState<any[]>([]);

  const load = () => {
    api.get("/orders").then((res) => setOrders(res.data));
  };

  useEffect(load, []);

  const updateStatus = async (id: string, status: string) => {
    try {
      await api.put(`/orders/${id}/status`, { status });
      toast.success("Status updated");
      load();
    } catch {
      toast.error("Failed to update");
    }
  };

  const getStatusColor = (status: string) => {
    switch (status) {
      case "Pending": return "bg-gray-400";
      case "OutForDelivery": return "bg-yellow-500";
      case "Delivered": return "bg-green-600";
      case "Cancelled": return "bg-red-500";
      default: return "bg-gray-300";
    }
  };

  return (
    <div>
      <h2 className="text-xl mb-4">Orders</h2>

      {orders.map((o) => (
        <div key={o.id} className="bg-white p-4 rounded shadow mb-3">
          <div className="flex justify-between">
            <p><b>{o.id}</b></p>
            <span className={`text-white px-2 py-1 rounded ${getStatusColor(o.status)}`}>
              {o.status}
            </span>
          </div>

          <p>Total: ₱{o.totalAmount}</p>

          <div className="flex gap-2 mt-3">
            <button onClick={() => updateStatus(o.id, "OutForDelivery")}
              className="bg-yellow-500 text-white px-2 py-1 rounded">
              Out
            </button>

            <button onClick={() => updateStatus(o.id, "Delivered")}
              className="bg-green-600 text-white px-2 py-1 rounded">
              Done
            </button>

            <button onClick={() => updateStatus(o.id, "Cancelled")}
              className="bg-red-500 text-white px-2 py-1 rounded">
              Cancel
            </button>
          </div>
        </div>
      ))}
    </div>
  );
}