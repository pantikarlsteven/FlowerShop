import { Link } from "react-router-dom";
import { useAuthStore } from "../store/authStore";

export default function Navbar() {
  const logout = useAuthStore((s) => s.logout);

  return (
    <nav className="bg-white shadow p-4 flex justify-between">
      <div className="flex gap-4">
        <Link to="/" className="font-bold text-pink-600">🌸 FlowerShop</Link>
        <Link to="/products">Products</Link>
        <Link to="/cart">Cart</Link>
      </div>

      <div className="flex gap-3">
        <Link to="/admin">Admin</Link>
        <button onClick={logout} className="text-red-500">Logout</button>
      </div>
    </nav>
  );
}