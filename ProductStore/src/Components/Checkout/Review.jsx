import React from 'react';
import { Typography, List, ListItem, ListItemText } from '@material-ui/core';

const Review = ({cart}) => (
  <>
    <Typography variant="h6" gutterBottom>Order summary</Typography>
    <List disablePadding>
      {cart.productCarts.map((item) => (
        <ListItem style={{ padding: '10px 0' }} key={item.product.name}>
          <ListItemText primary={item.product.name} secondary={`Quantity: ${item.quantity}`} />
          <Typography variant="body2">{(Math.round(item.product.price * item.quantity * 100) / 100).toFixed(2)}$</Typography>
        </ListItem>
      ))}
      <ListItem style={{ padding: '10px 0' }}>
        <ListItemText primary="Total" />
        <Typography variant="subtitle1" style={{ fontWeight: 700 }}>
          {cart.totalPrice}$
        </Typography>
      </ListItem>
    </List>
  </>
);

export default Review;