import React from 'react';
import { Typography, Button, Divider } from '@material-ui/core';
import { Elements, CardElement, ElementsConsumer } from '@stripe/react-stripe-js';
import { loadStripe } from '@stripe/stripe-js';

import Review from './Review';
const stripePromise = loadStripe('pk_test_TYooMQauvdEDq54NiTphI7jx');
const PaymentForm = ({cart, nextStep, backStep}) => {

    const handleSubmit = async (event, elements, stripe) => {
        event.preventDefault();
    
        if (!stripe || !elements) return;
    
        const cardElement = elements.getElement(CardElement);
    
        const { error, paymentMethod } = await stripe.createPaymentMethod({ type: 'card', card: cardElement });
    
        console.log(cardElement);
        console.log(cardElement);

        if(cardElement.complete)
          nextStep();
        }
         
  return (
    <>
      <Review  cart = {cart}/>
      <Divider />
      <Typography variant="h6" gutterBottom style={{ margin: '20px 0' }}>Payment method</Typography>
      <Elements stripe={stripePromise}>
        <ElementsConsumer>{({ elements, stripe }) => (
           <form onSubmit={(e) => handleSubmit(e, elements, stripe)}>
            <CardElement />
            <br /> <br />
            <div style={{ display: 'flex', justifyContent: 'space-between' }}>
              <Button variant="outlined" onClick={backStep} >Back</Button>
              <Button type="submit" variant="contained"  color="primary">
                Pay {cart.totalPrice}$
              </Button>
            </div>
          </form>
        )}
        </ElementsConsumer>
      </Elements>
    </>
  );
};

export default PaymentForm;