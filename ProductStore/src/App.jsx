import Products from "./Components/Products/Products";
import Navbar from "./Components/Navbar/Navbar";
import { useEffect, useState } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Cart from "./Components/Cart/Cart";
import Checkout from "./Components/Checkout/Checkout";
import axios from "axios";

const App = () => {
  const [products, setProducts] = useState([]);
  const [cart, setCart] = useState(null);
  const [order, setOrder] = useState(null);
  const [errorMessage, setErrorMessage] = useState("");

  const fetchProducts = async () => {
    try {
      const response = await axios.get("https://localhost:7292/api/Product");

      const data = response.data;
      setProducts(data);
    } catch (error) {
      console.error("Error fetching products:", error);
    }
  };

  const fetchCart = async () => {
    const cartId = localStorage.getItem("cartId");
    console.log(cartId);

    if (cartId === null) {
      const response = await axios.post("https://localhost:7292/api/Product");
      localStorage.setItem("cartId", response.data);
      return;
    }

    try {
      const response = await axios.get(
        `https://localhost:7292/api/Product/${cartId}`
      );
      setCart(response.data);
    } catch (error) {
      console.error("Error fetching cart:", error);
    }
  };

  const handleAddToCart = async (productId, quantity) => {
    const cartId = localStorage.getItem("cartId");
    const response = await axios.put(
      `https://localhost:7292/api/Product/${cartId}/${productId}/${quantity}`
    );
    const response2 = await axios.get(
      `https://localhost:7292/api/Product/${response.data}`
    );
    setCart(response2.data);
  };

  const handleUpdateCartQty = async (lineItemId, quantity) => {
    const cartId = localStorage.getItem("cartId");
    const response = await axios.put(
      `https://localhost:7292/api/Product/${cartId}/${lineItemId}/${quantity}`
    );
    const response2 = await axios.get(
      `https://localhost:7292/api/Product/${response.data}`
    );
    setCart(response2.data);
  };

  const handleRemoveFromCart = async (lineItemId) => {
    const cartId = localStorage.getItem("cartId");
    const response = await axios.delete(
      `https://localhost:7292/api/Product/${cartId}/${lineItemId}`
    );
    const response2 = await axios.get(
      `https://localhost:7292/api/Product/${response.data}`
    );
    setCart(response2.data);
  };

  const handleEmptyCart = async () => {
    const cartId = localStorage.getItem("cartId");
    const response = await axios.delete(
      `https://localhost:7292/api/Product/${cartId}`
    );
    const response2 = await axios.get(
      `https://localhost:7292/api/Product/${response.data}`
    );
    setCart(response2.data);
  };

  const refreshCart = async () => {
    const cartId = localStorage.getItem("cartId");
    const response2 = await axios.get(
      `https://localhost:7292/api/Product/${cartId}`
    );
    setCart(response2.data);
  };

  useEffect(() => {
    fetchProducts();
    fetchCart();
  }, []);

  return (
    <div>
      <Router>
        <Navbar totalItems={cart && cart.productCarts.length}></Navbar>
        <Routes>
          <Route
            exact
            path="/"
            element={
              <Products products={products} onAddToCart={handleAddToCart} />
            }
          />
          <Route
            exact
            path="/cart"
            element={
              <Cart
                cart={cart}
                onUpdateCartQty={handleUpdateCartQty}
                onRemoveFromCart={handleRemoveFromCart}
                onEmptyCart={handleEmptyCart}
              />
            }
          />
          <Route
            path="/checkout"
            exact
            element={
              <Checkout
                cart={cart}
                
              />
            }
          ></Route>
        </Routes>
      </Router>
    </div>
  );
};

export default App;
