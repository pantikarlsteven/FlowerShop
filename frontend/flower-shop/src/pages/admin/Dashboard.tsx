import { Link } from "react-router-dom";

export default function AdminDashboard() {
  return (
    <div>
      <h2 className="text-2xl mb-4">Admin Dashboard</h2>

      <div className="flex gap-4">
        <Link to="/admin/products" className="bg-blue-500 text-white p-4 rounded">
          Manage Products
        </Link>

        <Link to="/admin/orders" className="bg-green-500 text-white p-4 rounded">
          Manage Orders
        </Link>
      </div>
    </div>
  );
}