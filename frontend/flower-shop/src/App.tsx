import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./components/Layout";
import Home from "./pages/Home";
import Products from "./pages/Products";
import Cart from "./pages/Cart";
import Checkout from "./pages/Checkout";
import Login from "./pages/Login";
import AdminDashboard from "./pages/admin/Dashboard";
import AdminProducts from "./pages/admin/Products";
import ProtectedRoute from "./components/ProtectedRoute";
import AdminOrders from "./pages/admin/Orders";

function App() {
  return (
    <BrowserRouter>
      <Layout>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/products" element={<Products />} />
          <Route path="/cart" element={<Cart />} />
          <Route path="/checkout" element={<Checkout />} />
          <Route path="/login" element={<Login />} />

          {/* ADMIN */}
          <Route path="/admin" element={
            <ProtectedRoute role="Admin">
              <AdminDashboard />
            </ProtectedRoute>} />
          <Route
            path="/admin/orders"
            element={
              <ProtectedRoute role="Admin">
                <AdminOrders />
              </ProtectedRoute>
            }
          />
          <Route path="/admin/products" element={<AdminProducts />} />
        </Routes>
      </Layout>
    </BrowserRouter>
  );
}

export default App;