import React from 'react';
import { Typography, Button, Card, CardActions, CardContent, CardMedia } from '@material-ui/core';

import useStyles from './styles';
import {images} from "../../Products/Product/data";

const CartItem = ({ item, onUpdateCartQty, onRemoveFromCart }) => {
  const classes = useStyles();

  const handleUpdateCartQty = (lineItemId, newQuantity) => onUpdateCartQty(lineItemId, newQuantity);

  const handleRemoveFromCart = (lineItemId) => onRemoveFromCart(lineItemId);
    console.log(item);
  return (
    <Card className="cart-item">
      <CardMedia  image={images[item.product.imageName.split('.')[0]]} alt={item.name} className={classes.media} />
      <CardContent className={classes.cardContent}>
        <Typography variant="h4">{item.product.name}</Typography>
        <Typography variant="h5">{(Math.round(item.product.price * item.quantity * 100) / 100).toFixed(2)}$</Typography>
      </CardContent>
      <CardActions className={classes.cardActions}>
        <div className={classes.buttons}>
          <Button type="button" size="small" disabled={item.quantity - 1 === 0} onClick={() => handleUpdateCartQty(item.product.id, item.quantity - 1)}>-</Button>
          <Typography>&nbsp;{item.quantity}&nbsp;</Typography>
          <Button type="button" size="small" onClick={() => handleUpdateCartQty(item.product.id, item.quantity + 1)}>+</Button>
        </div>
        <Button variant="contained" type="button" color="secondary" onClick={() => handleRemoveFromCart(item.product.id)}>Remove</Button>
      </CardActions>
    </Card>
  );
};

export default CartItem;