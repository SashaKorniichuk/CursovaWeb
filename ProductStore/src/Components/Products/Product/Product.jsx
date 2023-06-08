import React from "react";
import {
    Card,
    CardMedia,
    CardContent,
    CardActions,
    Typography,
    IconButton,
} from "@material-ui/core";
import { AddShoppingCart } from "@material-ui/icons";
import {images} from "./data";

import useStyles from "./styles";
const Product = ({ product, onAddToCart }) => {
    const classes = useStyles();
    return (
        <Card className={classes.root}>
            <CardMedia
                className={classes.media}
                image={images[product.imageName.split('.')[0]]}
                title={product.name}
                component='image'
            />
            <CardContent>
                <div className={classes.cardContent}>
                    <Typography variant="h5" component="h2">
                        {product.name}
                    </Typography>
                    <Typography gutterBottom variant="h5" component="h2">
                        {product.price}$
                    </Typography>
                </div>
                
            </CardContent>
            <CardActions disableSpacing className={classes.cardActions}>
                <IconButton aria-label="Add to Cart" onClick={() => onAddToCart(product.id, 1)}>
                    <AddShoppingCart />
                </IconButton>
            </CardActions>
        </Card>
    );
};
export default Product;
