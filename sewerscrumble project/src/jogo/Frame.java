package jogo;

import java.awt.GridLayout;

import javax.swing.JFrame;

public class Frame extends JFrame {
	
	public Frame() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setTitle("Movimentacao do Jogador");
		setSize(400,400);
		setResizable(false);
		
	run();
		
		
	}
	
	public void run() {
		setLocationRelativeTo(null);
		
		setLayout(new GridLayout(1,1,0,0));
		
		Screen s = new Screen();
		
		add(s);
		
		setVisible(true);
	}
	
	public static void main (String[] args) {
		Frame f = new Frame();
	}
}
