import { useState } from "react";
import api from "../services/api";
import { useAuthStore } from "../store/authStore";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const setToken = useAuthStore((s) => s.setToken);
  const nav = useNavigate();

  const login = async () => {
    const res = await api.post("/auth/login", { username, password });
    setToken(res.data.token);
    nav("/");
  };

  return (
    <div>
      <h2>Login</h2>
      <input placeholder="username" onChange={(e) => setUsername(e.target.value)} />
      <input placeholder="password" type="password" onChange={(e) => setPassword(e.target.value)} />
      <button onClick={login}>Login</button>
    </div>
  );
}